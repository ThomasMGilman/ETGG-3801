// Fill out your copyright notice in the Description page of Project Settings.


#include "InvaderSpawner.h"
#include "Components/SphereComponent.h"

// Sets default values
AInvaderSpawner::AInvaderSpawner() : forward_time(0.0f), moving_left(true)
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
		USceneComponent* my_scene_root = (USceneComponent*)GetComponentByClass(USceneComponent::StaticClass());

		for (int x = 0; x < num_cols; x++)
		{
			for (int y = 0; y < num_rows; y++)
			{
				//Instatiate
				FVector loc = GetActorLocation() + FVector(x * (extents.Y + colSpacing), y * (extents.X + rowSpacing), 0);

				FTransform transform;
				transform.SetLocation(loc);

				FQuat rot = FQuat::MakeFromEuler(FVector(0, 0, 90));
				transform.SetRotation(rot);

				FActorSpawnParameters spawn_parameters;
				spawn_parameters.Owner = this;			//Not a Parent
				spawn_parameters.SpawnCollisionHandlingOverride = ESpawnActorCollisionHandlingMethod::AlwaysSpawn;

				//Spawn the invader here
				AActor* new_Invader = GetWorld()->SpawnActor(spawn_type.Get(), &transform, spawn_parameters);
				if (!new_Invader)
					LogString(*((FString)"new_Invader is null"));

#if WITH_EDITOR
				new_Invader->SetActorLabel("Invader_" + FString::FromInt(y) + "_" + FString::FromInt(x));
#endif
				//Parent Invader to our root scene node(Invader Spawner)
				new_Invader->AttachToComponent(my_scene_root, FAttachmentTransformRules::KeepWorldTransform);

				//Is this the first invader? if so, get its extents
				if (new_Invader && y == 0 && x == 0)
				{
					FBox box = new_Invader->GetComponentsBoundingBox();
					extents = box.GetExtent() * 2;
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

	FVector pos_Offset(0,0,0);
	if (move_forward_time > 0)
	{
		pos_Offset.X = move_speed;
		move_forward_time -= DeltaTime;
	}
	else
	{
		if (moving_left)
			pos_Offset.Y = move_speed;
		else
			pos_Offset.Y = -move_speed;
	}

	AddActorWorldOffset(pos_Offset * DeltaTime, true);
}


void AInvaderSpawner::hitWall()
{
	if (move_forward_time <= 0.0f)
	{
		move_forward_time = forward_time;

		//Get set up for when i stop moving forward
		moving_left = !moving_left;
	}
}
