// Fill out your copyright notice in the Description page of Project Settings.


#include "InvaderSpawner.h"
#include "Components/SphereComponent.h"

// Sets default values
AInvaderSpawner::AInvaderSpawner()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

	//make a sphere component the root component.
	USphereComponent* rootSComp = CreateDefaultSubobject<USphereComponent>(TEXT("MyRoot"));
	RootComponent = rootSComp;
	rootSComp->InitSphereRadius(1.0f);
}

// Called when the game starts or when spawned
void AInvaderSpawner::BeginPlay()
{
	Super::BeginPlay();
	
	if (spawn_type != NULL)
	{
		FVector extents;

		for (int x = 0; x < num_cols; x++)
		{
			for (int y = 0; y < num_rows; y++)
			{
				//Instatiate
				FVector loc = GetActorLocation() + FVector(x * extents.Y, y * extents.X, 0);

				FTransform transform;
				transform.SetLocation(loc);

				FQuat rot = FQuat::MakeFromEuler(FVector(0, 0, 90));
				transform.SetRotation(rot);

				FActorSpawnParameters spawn_parameters;
				spawn_parameters.Owner = this;			//Not a Parent
				spawn_parameters.SpawnCollisionHandlingOverride = ESpawnActorCollisionHandlingMethod::AlwaysSpawn;

				AActor* new_Invader = GetWorld()->SpawnActor(spawn_type.Get(), &transform, spawn_parameters);

				if (!new_Invader)
					LogString(*((FString)"new_Invader is null"));

				//Is this the first invader? if so, get its extents
				if (new_Invader && y == 0 && x == 0)
				{
					FBox box = new_Invader->GetComponentsBoundingBox();
					extents = box.GetExtent();
					//SET_LOG_COLOR()
					LogString(*("Extents: "+extents.ToString()));
				}
			}
		}
	}
	else
		UE_LOG(LogTemp, Error, TEXT("Extents: %s"), "Spawn_Type is Null!!!\n\tNeed to set Spawn_Type to its specified BP\n");
}

// Called every frame
void AInvaderSpawner::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);
}

