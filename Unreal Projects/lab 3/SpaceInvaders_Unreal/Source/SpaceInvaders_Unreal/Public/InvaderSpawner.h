// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "GameFramework/Actor.h"
#include "InvaderSpawner.generated.h"

UCLASS()
class SPACEINVADERS_UNREAL_API AInvaderSpawner : public AActor
{
	GENERATED_BODY()
	
public:	
	// Sets default values for this actor's properties
	AInvaderSpawner();
	
	//The number of Rows of the Invader Fleet
	UPROPERTY(EditAnywhere, Category = "InvaderVariables")
		int32 num_rows = 10;

	//The number of Columns of the Invader Fleet
	UPROPERTY(EditAnywhere, Category = "InvaderVariables")
		int32 num_cols = 10;

	UPROPERTY(EditAnywhere, Category = "InvaderVariables")
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