// Copyright 1998-2019 Epic Games, Inc. All Rights Reserved.
/*===========================================================================
	Generated code exported from UnrealHeaderTool.
	DO NOT modify this manually! Edit the corresponding .h files instead!
===========================================================================*/

#include "UObject/GeneratedCppIncludes.h"
#include "MissleComnder/worldSpawner.h"
#ifdef _MSC_VER
#pragma warning (push)
#pragma warning (disable : 4883)
#endif
PRAGMA_DISABLE_DEPRECATION_WARNINGS
void EmptyLinkFunctionForGeneratedCodeworldSpawner() {}
// Cross Module References
	MISSLECOMNDER_API UClass* Z_Construct_UClass_AworldSpawner_NoRegister();
	MISSLECOMNDER_API UClass* Z_Construct_UClass_AworldSpawner();
	ENGINE_API UClass* Z_Construct_UClass_AActor();
	UPackage* Z_Construct_UPackage__Script_MissleComnder();
	ENGINE_API UClass* Z_Construct_UClass_AActor_NoRegister();
	COREUOBJECT_API UClass* Z_Construct_UClass_UClass();
	ENGINE_API UClass* Z_Construct_UClass_UInstancedStaticMeshComponent_NoRegister();
	COREUOBJECT_API UScriptStruct* Z_Construct_UScriptStruct_FVector();
// End Cross Module References
	void AworldSpawner::StaticRegisterNativesAworldSpawner()
	{
	}
	UClass* Z_Construct_UClass_AworldSpawner_NoRegister()
	{
		return AworldSpawner::StaticClass();
	}
	struct Z_Construct_UClass_AworldSpawner_Statics
	{
		static UObject* (*const DependentSingletons[])();
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Class_MetaDataParams[];
#endif
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_Player_SpawnType_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_Player_SpawnType;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_GroundInstance_MetaData[];
#endif
		static const UE4CodeGen_Private::FClassPropertyParams NewProp_GroundInstance;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_MeshInstances_MetaData[];
#endif
		static const UE4CodeGen_Private::FObjectPropertyParams NewProp_MeshInstances;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_row_Spacing_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_row_Spacing;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_col_Spacing_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_col_Spacing;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_startLocation_MetaData[];
#endif
		static const UE4CodeGen_Private::FStructPropertyParams NewProp_startLocation;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_world_Height_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_world_Height;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_zWave_Amplitude_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_zWave_Amplitude;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_xWave_Amplitude_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_xWave_Amplitude;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_wave_Amplitude_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_wave_Amplitude;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_turret_Count_MetaData[];
#endif
		static const UE4CodeGen_Private::FIntPropertyParams NewProp_turret_Count;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_world_Depth_MetaData[];
#endif
		static const UE4CodeGen_Private::FIntPropertyParams NewProp_world_Depth;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_world_Width_MetaData[];
#endif
		static const UE4CodeGen_Private::FIntPropertyParams NewProp_world_Width;
		static const UE4CodeGen_Private::FPropertyParamsBase* const PropPointers[];
		static const FCppClassTypeInfoStatic StaticCppClassTypeInfo;
		static const UE4CodeGen_Private::FClassParams ClassParams;
	};
	UObject* (*const Z_Construct_UClass_AworldSpawner_Statics::DependentSingletons[])() = {
		(UObject* (*)())Z_Construct_UClass_AActor,
		(UObject* (*)())Z_Construct_UPackage__Script_MissleComnder,
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AworldSpawner_Statics::Class_MetaDataParams[] = {
		{ "IncludePath", "worldSpawner.h" },
		{ "ModuleRelativePath", "worldSpawner.h" },
	};
#endif
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AworldSpawner_Statics::NewProp_Player_SpawnType_MetaData[] = {
		{ "Category", "WorldVariables" },
		{ "ModuleRelativePath", "worldSpawner.h" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_AworldSpawner_Statics::NewProp_Player_SpawnType = { "Player_SpawnType", nullptr, (EPropertyFlags)0x0010000000000001, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AworldSpawner, Player_SpawnType), Z_Construct_UClass_AActor_NoRegister, METADATA_PARAMS(Z_Construct_UClass_AworldSpawner_Statics::NewProp_Player_SpawnType_MetaData, ARRAY_COUNT(Z_Construct_UClass_AworldSpawner_Statics::NewProp_Player_SpawnType_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AworldSpawner_Statics::NewProp_GroundInstance_MetaData[] = {
		{ "Category", "WorldVariables" },
		{ "ModuleRelativePath", "worldSpawner.h" },
	};
#endif
	const UE4CodeGen_Private::FClassPropertyParams Z_Construct_UClass_AworldSpawner_Statics::NewProp_GroundInstance = { "GroundInstance", nullptr, (EPropertyFlags)0x0014000000000001, UE4CodeGen_Private::EPropertyGenFlags::Class, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AworldSpawner, GroundInstance), Z_Construct_UClass_AActor_NoRegister, Z_Construct_UClass_UClass, METADATA_PARAMS(Z_Construct_UClass_AworldSpawner_Statics::NewProp_GroundInstance_MetaData, ARRAY_COUNT(Z_Construct_UClass_AworldSpawner_Statics::NewProp_GroundInstance_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AworldSpawner_Statics::NewProp_MeshInstances_MetaData[] = {
		{ "Category", "WorldVariables" },
		{ "EditInline", "true" },
		{ "ModuleRelativePath", "worldSpawner.h" },
	};
#endif
	const UE4CodeGen_Private::FObjectPropertyParams Z_Construct_UClass_AworldSpawner_Statics::NewProp_MeshInstances = { "MeshInstances", nullptr, (EPropertyFlags)0x0010000000080009, UE4CodeGen_Private::EPropertyGenFlags::Object, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AworldSpawner, MeshInstances), Z_Construct_UClass_UInstancedStaticMeshComponent_NoRegister, METADATA_PARAMS(Z_Construct_UClass_AworldSpawner_Statics::NewProp_MeshInstances_MetaData, ARRAY_COUNT(Z_Construct_UClass_AworldSpawner_Statics::NewProp_MeshInstances_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AworldSpawner_Statics::NewProp_row_Spacing_MetaData[] = {
		{ "Category", "WorldVariables" },
		{ "ModuleRelativePath", "worldSpawner.h" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_AworldSpawner_Statics::NewProp_row_Spacing = { "row_Spacing", nullptr, (EPropertyFlags)0x0010000000000001, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AworldSpawner, row_Spacing), METADATA_PARAMS(Z_Construct_UClass_AworldSpawner_Statics::NewProp_row_Spacing_MetaData, ARRAY_COUNT(Z_Construct_UClass_AworldSpawner_Statics::NewProp_row_Spacing_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AworldSpawner_Statics::NewProp_col_Spacing_MetaData[] = {
		{ "Category", "WorldVariables" },
		{ "ModuleRelativePath", "worldSpawner.h" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_AworldSpawner_Statics::NewProp_col_Spacing = { "col_Spacing", nullptr, (EPropertyFlags)0x0010000000000001, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AworldSpawner, col_Spacing), METADATA_PARAMS(Z_Construct_UClass_AworldSpawner_Statics::NewProp_col_Spacing_MetaData, ARRAY_COUNT(Z_Construct_UClass_AworldSpawner_Statics::NewProp_col_Spacing_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AworldSpawner_Statics::NewProp_startLocation_MetaData[] = {
		{ "Category", "WorldVariables" },
		{ "ModuleRelativePath", "worldSpawner.h" },
	};
#endif
	const UE4CodeGen_Private::FStructPropertyParams Z_Construct_UClass_AworldSpawner_Statics::NewProp_startLocation = { "startLocation", nullptr, (EPropertyFlags)0x0010000000000001, UE4CodeGen_Private::EPropertyGenFlags::Struct, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AworldSpawner, startLocation), Z_Construct_UScriptStruct_FVector, METADATA_PARAMS(Z_Construct_UClass_AworldSpawner_Statics::NewProp_startLocation_MetaData, ARRAY_COUNT(Z_Construct_UClass_AworldSpawner_Statics::NewProp_startLocation_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AworldSpawner_Statics::NewProp_world_Height_MetaData[] = {
		{ "Category", "WorldVariables" },
		{ "ModuleRelativePath", "worldSpawner.h" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_AworldSpawner_Statics::NewProp_world_Height = { "world_Height", nullptr, (EPropertyFlags)0x0010000000000001, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AworldSpawner, world_Height), METADATA_PARAMS(Z_Construct_UClass_AworldSpawner_Statics::NewProp_world_Height_MetaData, ARRAY_COUNT(Z_Construct_UClass_AworldSpawner_Statics::NewProp_world_Height_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AworldSpawner_Statics::NewProp_zWave_Amplitude_MetaData[] = {
		{ "Category", "WorldVariables" },
		{ "ModuleRelativePath", "worldSpawner.h" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_AworldSpawner_Statics::NewProp_zWave_Amplitude = { "zWave_Amplitude", nullptr, (EPropertyFlags)0x0010000000000001, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AworldSpawner, zWave_Amplitude), METADATA_PARAMS(Z_Construct_UClass_AworldSpawner_Statics::NewProp_zWave_Amplitude_MetaData, ARRAY_COUNT(Z_Construct_UClass_AworldSpawner_Statics::NewProp_zWave_Amplitude_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AworldSpawner_Statics::NewProp_xWave_Amplitude_MetaData[] = {
		{ "Category", "WorldVariables" },
		{ "ModuleRelativePath", "worldSpawner.h" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_AworldSpawner_Statics::NewProp_xWave_Amplitude = { "xWave_Amplitude", nullptr, (EPropertyFlags)0x0010000000000001, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AworldSpawner, xWave_Amplitude), METADATA_PARAMS(Z_Construct_UClass_AworldSpawner_Statics::NewProp_xWave_Amplitude_MetaData, ARRAY_COUNT(Z_Construct_UClass_AworldSpawner_Statics::NewProp_xWave_Amplitude_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AworldSpawner_Statics::NewProp_wave_Amplitude_MetaData[] = {
		{ "Category", "WorldVariables" },
		{ "ModuleRelativePath", "worldSpawner.h" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_AworldSpawner_Statics::NewProp_wave_Amplitude = { "wave_Amplitude", nullptr, (EPropertyFlags)0x0010000000000001, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AworldSpawner, wave_Amplitude), METADATA_PARAMS(Z_Construct_UClass_AworldSpawner_Statics::NewProp_wave_Amplitude_MetaData, ARRAY_COUNT(Z_Construct_UClass_AworldSpawner_Statics::NewProp_wave_Amplitude_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AworldSpawner_Statics::NewProp_turret_Count_MetaData[] = {
		{ "Category", "WorldVariables" },
		{ "ModuleRelativePath", "worldSpawner.h" },
	};
#endif
	const UE4CodeGen_Private::FIntPropertyParams Z_Construct_UClass_AworldSpawner_Statics::NewProp_turret_Count = { "turret_Count", nullptr, (EPropertyFlags)0x0010000000000001, UE4CodeGen_Private::EPropertyGenFlags::Int, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AworldSpawner, turret_Count), METADATA_PARAMS(Z_Construct_UClass_AworldSpawner_Statics::NewProp_turret_Count_MetaData, ARRAY_COUNT(Z_Construct_UClass_AworldSpawner_Statics::NewProp_turret_Count_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AworldSpawner_Statics::NewProp_world_Depth_MetaData[] = {
		{ "Category", "WorldVariables" },
		{ "ModuleRelativePath", "worldSpawner.h" },
	};
#endif
	const UE4CodeGen_Private::FIntPropertyParams Z_Construct_UClass_AworldSpawner_Statics::NewProp_world_Depth = { "world_Depth", nullptr, (EPropertyFlags)0x0010000000000001, UE4CodeGen_Private::EPropertyGenFlags::Int, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AworldSpawner, world_Depth), METADATA_PARAMS(Z_Construct_UClass_AworldSpawner_Statics::NewProp_world_Depth_MetaData, ARRAY_COUNT(Z_Construct_UClass_AworldSpawner_Statics::NewProp_world_Depth_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AworldSpawner_Statics::NewProp_world_Width_MetaData[] = {
		{ "Category", "WorldVariables" },
		{ "ModuleRelativePath", "worldSpawner.h" },
	};
#endif
	const UE4CodeGen_Private::FIntPropertyParams Z_Construct_UClass_AworldSpawner_Statics::NewProp_world_Width = { "world_Width", nullptr, (EPropertyFlags)0x0010000000000001, UE4CodeGen_Private::EPropertyGenFlags::Int, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AworldSpawner, world_Width), METADATA_PARAMS(Z_Construct_UClass_AworldSpawner_Statics::NewProp_world_Width_MetaData, ARRAY_COUNT(Z_Construct_UClass_AworldSpawner_Statics::NewProp_world_Width_MetaData)) };
	const UE4CodeGen_Private::FPropertyParamsBase* const Z_Construct_UClass_AworldSpawner_Statics::PropPointers[] = {
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AworldSpawner_Statics::NewProp_Player_SpawnType,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AworldSpawner_Statics::NewProp_GroundInstance,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AworldSpawner_Statics::NewProp_MeshInstances,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AworldSpawner_Statics::NewProp_row_Spacing,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AworldSpawner_Statics::NewProp_col_Spacing,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AworldSpawner_Statics::NewProp_startLocation,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AworldSpawner_Statics::NewProp_world_Height,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AworldSpawner_Statics::NewProp_zWave_Amplitude,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AworldSpawner_Statics::NewProp_xWave_Amplitude,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AworldSpawner_Statics::NewProp_wave_Amplitude,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AworldSpawner_Statics::NewProp_turret_Count,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AworldSpawner_Statics::NewProp_world_Depth,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AworldSpawner_Statics::NewProp_world_Width,
	};
	const FCppClassTypeInfoStatic Z_Construct_UClass_AworldSpawner_Statics::StaticCppClassTypeInfo = {
		TCppClassTypeTraits<AworldSpawner>::IsAbstract,
	};
	const UE4CodeGen_Private::FClassParams Z_Construct_UClass_AworldSpawner_Statics::ClassParams = {
		&AworldSpawner::StaticClass,
		nullptr,
		&StaticCppClassTypeInfo,
		DependentSingletons,
		nullptr,
		Z_Construct_UClass_AworldSpawner_Statics::PropPointers,
		nullptr,
		ARRAY_COUNT(DependentSingletons),
		0,
		ARRAY_COUNT(Z_Construct_UClass_AworldSpawner_Statics::PropPointers),
		0,
		0x009000A0u,
		METADATA_PARAMS(Z_Construct_UClass_AworldSpawner_Statics::Class_MetaDataParams, ARRAY_COUNT(Z_Construct_UClass_AworldSpawner_Statics::Class_MetaDataParams))
	};
	UClass* Z_Construct_UClass_AworldSpawner()
	{
		static UClass* OuterClass = nullptr;
		if (!OuterClass)
		{
			UE4CodeGen_Private::ConstructUClass(OuterClass, Z_Construct_UClass_AworldSpawner_Statics::ClassParams);
		}
		return OuterClass;
	}
	IMPLEMENT_CLASS(AworldSpawner, 1061745464);
	template<> MISSLECOMNDER_API UClass* StaticClass<AworldSpawner>()
	{
		return AworldSpawner::StaticClass();
	}
	static FCompiledInDefer Z_CompiledInDefer_UClass_AworldSpawner(Z_Construct_UClass_AworldSpawner, &AworldSpawner::StaticClass, TEXT("/Script/MissleComnder"), TEXT("AworldSpawner"), false, nullptr, nullptr, nullptr);
	DEFINE_VTABLE_PTR_HELPER_CTOR(AworldSpawner);
PRAGMA_ENABLE_DEPRECATION_WARNINGS
#ifdef _MSC_VER
#pragma warning (pop)
#endif
