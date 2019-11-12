// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Engine/Classes/Components/StaticMeshComponent.h"
#include "Engine/Classes/Components/InstancedStaticMeshComponent.h"
#include "GameFramework/Actor.h"
#include "worldSpawner.generated.h"

UCLASS()
class MISSLECOMNDER_API AworldSpawner : public AActor
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	AworldSpawner();

	UPROPERTY(EditAnywhere, Category = "WorldVariables")
		int32 world_Width = 10;

	UPROPERTY(EditAnywhere, Category = "WorldVariables")
		int32 world_Depth = 10;

	UPROPERTY(EditAnywhere, Category = "WorldVariables")
		int32 turret_Count = 10;

	UPROPERTY(EditAnywhere, Category = "WorldVariables")
		float wave_Amplitude = 1;

	UPROPERTY(EditAnywhere, Category = "WorldVariables")
		float xWave_Amplitude = 1;

	UPROPERTY(EditAnywhere, Category = "WorldVariables")
		float zWave_Amplitude = 1;

	UPROPERTY(EditAnywhere, Category = "WorldVariables")
		float world_Height = 1;

	UPROPERTY(EditAnywhere, Category = "WorldVariables")
		float col_Spacing = 1;

	UPROPERTY(EditAnywhere, Category = "WorldVariables")
		float row_Spacing = 1;

	UPROPERTY(EditAnywhere, Category = "WorldVariables")
		TSubclassOf<class AActor> spawn_type;

	UPROPERTY(EditAnywhere, Category = "WorldVariables")
		UStaticMesh *StaticMesh;

	void LogString(const TCHAR* msg)
	{
		UE_LOG(LogTemp, Log, TEXT("%s"), msg);
	}

	// Called every frame
	virtual void Tick(float DeltaTime) override;

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

private:	
	
	//UInstancedStaticMeshComponent* InstancedStaticMeshComponent;
};
