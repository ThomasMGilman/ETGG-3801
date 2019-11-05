// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "worldSpawner.generated.h"

UCLASS()
class MISSLECOMNDER_API AworldSpawner : public AActor
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	AworldSpawner();

	UPROPERTY(EditAnywhere, Category = "WorldSpawn_Variables")
		int32 world_Width = 10;
	UPROPERTY(EditAnywhere, Category = "WorldSpawn_Variables")
		int32 world_Depth = 10;

	UPROPERTY(EditAnywhere, Category = "WorldSpawn_Variables")
		float world_Height = 1;
	UPROPERTY(EditAnywhere, Category = "WorldSpawn_Variables")
		float col_Spacing = 1;
	UPROPERTY(EditAnywhere, Category = "WorldSpawn_Variables")
		float row_Spacing = 1;

	UPROPERTY(EditAnywhere, Category = "WorldSpawn_Variables")
		TSubclassOf<class AActor> spawn_type;

	void LogString(const TCHAR* msg)
	{
		UE_LOG(LogTemp, Log, TEXT("%s"), msg);
	}

protected:
	// Called when the game starts or when spawned
	virtual void BeginPlay() override;

public:	
	// Called every frame
	virtual void Tick(float DeltaTime) override;
};
