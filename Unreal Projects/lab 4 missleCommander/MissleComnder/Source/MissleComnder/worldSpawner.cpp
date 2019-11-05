// Fill out your copyright notice in the Description page of Project Settings.


#include "worldSpawner.h"
#include "Components/SphereComponent.h"

// Sets default values
AworldSpawner::AworldSpawner()
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

	//make a sphere component the root component.
	USphereComponent* rootSComp = CreateDefaultSubobject<USphereComponent>(TEXT("MyRoot"));
	RootComponent = rootSComp;
	rootSComp->InitSphereRadius(1.0f);
}

// Called when the game starts or when spawned
void AworldSpawner::BeginPlay()
{
	Super::BeginPlay();

	if (spawn_type != NULL)
	{
		FVector extents;
		USceneComponent* my_scene_root = (USceneComponent*)GetComponentByClass(USceneComponent::StaticClass());

		for (int x = -world_Width / 2; x < world_Width / 2; x++)
		{
			for (int z = -world_Depth / 2; z < world_Depth / 2; z++)
			{
				FVector loc = GetActorLocation() + FVector(x * (extents.Y + col_Spacing), z * (extents.X + row_Spacing), 0);
				FTransform transform;
				transform.SetLocation(loc);

				FActorSpawnParameters spawn_params;
				spawn_params.Owner = this;
				spawn_params.SpawnCollisionHandlingOverride = ESpawnActorCollisionHandlingMethod::AlwaysSpawn;

				AActor* new_Ground_Block = GetWorld()->SpawnActor(spawn_type.Get(), &transform, spawn_params);
				if (!new_Ground_Block)
					LogString(*((FString)"Ground block is null for some reason"));

				#if WITH_EDITOR
				new_Ground_Block->SetActorLabel("Block_" + FString::FromInt(z) + "_" + FString::FromInt(x));
				#endif

				new_Ground_Block->AttachToComponent(my_scene_root, FAttachmentTransformRules::KeepWorldTransform);
				if (new_Ground_Block && x == 0 && z == 0)
				{
					FBox box = new_Ground_Block->GetComponentsBoundingBox();
					extents = box.GetExtent() * 2;
					LogString(*("Extents: " + extents.ToString()));
				}
			}
		}
	}
	else
		UE_LOG(LogTemp, Error, TEXT("Extents: %s"), "Spawn_Type is Null!!!\n\tNeed to set Spawn_Type to its specified BP\n");
}

// Called every frame
void AworldSpawner::Tick(float DeltaTime)
{
	Super::Tick(DeltaTime);

}
