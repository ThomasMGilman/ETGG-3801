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

	//InstancedStaticMeshComponent = NewObject<UInstancedStaticMeshComponent>();
	//InstancedStaticMeshComponent->SetStaticMesh(StaticMesh);
	//InstancedStaticMeshComponent->RegisterComponentWithWorld(GetWorld());
}

// Called when the game starts or when spawned
void AworldSpawner::BeginPlay()
{
	//Super::BeginPlay();

	if (spawn_type != NULL)
	{
		FVector extents;
		USceneComponent* my_scene_root = (USceneComponent*)GetComponentByClass(USceneComponent::StaticClass());
		AActor* new_Ground_Block;
		UInstancedStaticMeshComponent* InstancedStaticMeshComponent = NewObject<UInstancedStaticMeshComponent>();
		float XangleIncrement = 360 / xWave_Amplitude, ZanlgeIncrement = 360 / zWave_Amplitude;
		int halfWidth = world_Width / 2, halfDepth = world_Depth / 2;

		for (int x = 0; x < world_Width; x++)
		{
			float xPos = x * (extents.Y + col_Spacing) - halfWidth;		//SET X LOCATION OF BLOCK
			float angleX = ((xPos) * XangleIncrement * PI) / 180; //convert to radians
			for (int z = 0; z < world_Depth; z++)
			{
				float zPos = z * (extents.X + row_Spacing) - halfDepth;			//SET Z LOCATION OF BLOCK
				float angleZ = ((zPos) * ZanlgeIncrement * PI) / 180;
				float yPos = sinf(angleZ * wave_Amplitude) * cosf(angleX * wave_Amplitude);

				FVector loc = GetActorLocation() + FVector(xPos, zPos, yPos);
				FTransform transform;
				transform.SetLocation(loc);										//Set objects location

				FActorSpawnParameters spawn_params;								//Set owner and collision
				spawn_params.Owner = this;
				spawn_params.SpawnCollisionHandlingOverride = ESpawnActorCollisionHandlingMethod::AlwaysSpawn;

				if (x == 0 && z == 0)
				{
					new_Ground_Block = GetWorld()->SpawnActor(spawn_type.Get(), &transform, spawn_params);
					if (!new_Ground_Block)
						LogString(*((FString)"Ground block is null for some reason"));

#if WITH_EDITOR
					new_Ground_Block->SetActorLabel("Block_" + FString::FromInt(z) + "_" + FString::FromInt(x));
#endif
					InstancedStaticMeshComponent->RegisterComponentWithWorld(GetWorld());

					InstancedStaticMeshComponent->AttachToComponent(new_Ground_Block->GetRootComponent(), FAttachmentTransformRules::KeepWorldTransform); //attach Instanced Static Mesh to new Actor
					InstancedStaticMeshComponent->AddInstanceWorldSpace(transform);

					new_Ground_Block->AttachToComponent(my_scene_root, FAttachmentTransformRules::KeepWorldTransform);
					if (new_Ground_Block)
					{
						FBox box = new_Ground_Block->GetComponentsBoundingBox();
						extents = box.GetExtent() * 2;
						LogString(*("Extents: " + extents.ToString()));
					}
				}
				else
					InstancedStaticMeshComponent->AddInstanceWorldSpace(transform);
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
