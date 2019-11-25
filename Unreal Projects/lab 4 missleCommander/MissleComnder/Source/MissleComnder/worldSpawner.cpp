// Fill out your copyright notice in the Description page of Project Settings.


#include "worldSpawner.h"
#include "Components/SphereComponent.h"
#include "Math/UnrealMathUtility.h"

// Sets default values
AworldSpawner::AworldSpawner(const FObjectInitializer& ObjectInitializer) : Super(ObjectInitializer)
{
 	// Set this actor to call Tick() every frame.  You can turn this off to improve performance if you don't need it.
	PrimaryActorTick.bCanEverTick = true;

	MeshInstances = ObjectInitializer.CreateDefaultSubobject<UInstancedStaticMeshComponent>(this, TEXT("MeshInstances"));
	RootComponent = MeshInstances;
}

// Called when the game starts or when spawned
void AworldSpawner::BeginPlay()
{
	Super::BeginPlay();

	FActorSpawnParameters spawnParams;
	spawnParams.Owner = this;
	spawnParams.SpawnCollisionHandlingOverride = ESpawnActorCollisionHandlingMethod::AdjustIfPossibleButAlwaysSpawn;

	FTransform InstanceTransform;
	InstanceTransform.SetLocation(startLocation);
	
	AActor* ground = GetWorld()->SpawnActor(GroundInstance.Get(), &InstanceTransform, spawnParams);

	if (GroundInstance != NULL)
	{
		MeshInstances->AttachTo(ground->GetRootComponent());
		MeshInstances->RegisterComponent();
		FTransform transform;
		float XangleIncrement = 360 / xWave_Amplitude, ZanlgeIncrement = 360 / zWave_Amplitude;
		int halfWidth = world_Width / 2, halfDepth = world_Depth / 2;

		for (int x = 0; x < world_Width; x++)
		{
			float xPos = startLocation.X - x * col_Spacing - halfWidth;		//SET X LOCATION OF BLOCK
			float angleX = ((xPos) * XangleIncrement * PI) / 180; //convert to radians
			for (int z = 0; z < world_Depth; z++)
			{
				float zPos = startLocation.Y + (z * row_Spacing - halfDepth);			//SET Z LOCATION OF BLOCK
				float angleZ = ((zPos) * ZanlgeIncrement * PI) / 180;
				float yPos = sinf(angleZ * wave_Amplitude) * cosf(angleX * wave_Amplitude) * wave_Amplitude;

				//Set objects location
				FVector curPos = FVector(xPos, zPos, yPos);
				InstanceTransform.SetLocation(GetActorLocation() + curPos);	//Set Instance Location and place Instance
				MeshInstances->AddInstance(InstanceTransform);
				

				if (x == halfWidth - 1 && z == halfDepth - 1)	//Spawn Player
				{
					float turret_AngleInc = 360 / turret_Count;
					transform.SetLocation(curPos + FVector(0, 0, base_heightOffset));
					AActor* base = GetWorld()->SpawnActor(Base_SpawnType.Get(), &transform, spawnParams);			//Spawn Base

					for (int turNum = 0; turNum < turret_Count; turNum++)
					{
						float turretAngle = (float)((turret_AngleInc * PI) / 180);
						float turPosX = turret_radiusMul * turret_radius * cos((turNum + 1) * turretAngle) + xPos;
						float turPosY = turret_radiusMul * turret_radius * sin((turNum + 1) * turretAngle) + zPos;
						float turPosZ = sinf(((turPosY * ZanlgeIncrement * PI) / 180) * wave_Amplitude) * cosf(((turPosX * XangleIncrement * PI) / 180) * wave_Amplitude) * wave_Amplitude;
						FVector turPos = FVector(turPosX, turPosY, turPosZ + turret_heightOffset);

						transform.SetLocation(turPos);
						AActor* newTurret = GetWorld()->SpawnActor(Turret_SpawnType.Get(), &transform, spawnParams);
					}
					//Player_SpawnType->SetActorLocation(GetActorLocation() + FVector(xPos, zPos, yPos + 100));
					//GetWorld()->SpawnActor(Player_SpawnType.Get(), &InstanceTransform);
					//UE_LOG(LogTemp, Warning, TEXT("spawning actor"));
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
