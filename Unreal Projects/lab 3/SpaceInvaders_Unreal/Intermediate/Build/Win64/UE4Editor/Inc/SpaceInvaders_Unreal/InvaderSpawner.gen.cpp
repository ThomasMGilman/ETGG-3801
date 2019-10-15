// Copyright 1998-2019 Epic Games, Inc. All Rights Reserved.
/*===========================================================================
	Generated code exported from UnrealHeaderTool.
	DO NOT modify this manually! Edit the corresponding .h files instead!
===========================================================================*/

#include "UObject/GeneratedCppIncludes.h"
#include "SpaceInvaders_Unreal/Public/InvaderSpawner.h"
#ifdef _MSC_VER
#pragma warning (push)
#pragma warning (disable : 4883)
#endif
PRAGMA_DISABLE_DEPRECATION_WARNINGS
void EmptyLinkFunctionForGeneratedCodeInvaderSpawner() {}
// Cross Module References
	SPACEINVADERS_UNREAL_API UClass* Z_Construct_UClass_AInvaderSpawner_NoRegister();
	SPACEINVADERS_UNREAL_API UClass* Z_Construct_UClass_AInvaderSpawner();
	ENGINE_API UClass* Z_Construct_UClass_AActor();
	UPackage* Z_Construct_UPackage__Script_SpaceInvaders_Unreal();
	COREUOBJECT_API UClass* Z_Construct_UClass_UClass();
	ENGINE_API UClass* Z_Construct_UClass_AActor_NoRegister();
// End Cross Module References
	void AInvaderSpawner::StaticRegisterNativesAInvaderSpawner()
	{
	}
	UClass* Z_Construct_UClass_AInvaderSpawner_NoRegister()
	{
		return AInvaderSpawner::StaticClass();
	}
	struct Z_Construct_UClass_AInvaderSpawner_Statics
	{
		static UObject* (*const DependentSingletons[])();
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Class_MetaDataParams[];
#endif
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_spawn_type_MetaData[];
#endif
		static const UE4CodeGen_Private::FClassPropertyParams NewProp_spawn_type;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_num_cols_MetaData[];
#endif
		static const UE4CodeGen_Private::FIntPropertyParams NewProp_num_cols;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_num_rows_MetaData[];
#endif
		static const UE4CodeGen_Private::FIntPropertyParams NewProp_num_rows;
		static const UE4CodeGen_Private::FPropertyParamsBase* const PropPointers[];
		static const FCppClassTypeInfoStatic StaticCppClassTypeInfo;
		static const UE4CodeGen_Private::FClassParams ClassParams;
	};
	UObject* (*const Z_Construct_UClass_AInvaderSpawner_Statics::DependentSingletons[])() = {
		(UObject* (*)())Z_Construct_UClass_AActor,
		(UObject* (*)())Z_Construct_UPackage__Script_SpaceInvaders_Unreal,
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AInvaderSpawner_Statics::Class_MetaDataParams[] = {
		{ "IncludePath", "InvaderSpawner.h" },
		{ "ModuleRelativePath", "Public/InvaderSpawner.h" },
	};
#endif
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_spawn_type_MetaData[] = {
		{ "Category", "InvaderVariables" },
		{ "ModuleRelativePath", "Public/InvaderSpawner.h" },
	};
#endif
	const UE4CodeGen_Private::FClassPropertyParams Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_spawn_type = { "spawn_type", nullptr, (EPropertyFlags)0x0014000000000001, UE4CodeGen_Private::EPropertyGenFlags::Class, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AInvaderSpawner, spawn_type), Z_Construct_UClass_AActor_NoRegister, Z_Construct_UClass_UClass, METADATA_PARAMS(Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_spawn_type_MetaData, ARRAY_COUNT(Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_spawn_type_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_num_cols_MetaData[] = {
		{ "Category", "InvaderVariables" },
		{ "Comment", "//The number of Columns of the Invader Fleet\n" },
		{ "ModuleRelativePath", "Public/InvaderSpawner.h" },
		{ "ToolTip", "The number of Columns of the Invader Fleet" },
	};
#endif
	const UE4CodeGen_Private::FIntPropertyParams Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_num_cols = { "num_cols", nullptr, (EPropertyFlags)0x0010000000000001, UE4CodeGen_Private::EPropertyGenFlags::Int, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AInvaderSpawner, num_cols), METADATA_PARAMS(Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_num_cols_MetaData, ARRAY_COUNT(Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_num_cols_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_num_rows_MetaData[] = {
		{ "Category", "InvaderVariables" },
		{ "Comment", "//The number of Rows of the Invader Fleet\n" },
		{ "ModuleRelativePath", "Public/InvaderSpawner.h" },
		{ "ToolTip", "The number of Rows of the Invader Fleet" },
	};
#endif
	const UE4CodeGen_Private::FIntPropertyParams Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_num_rows = { "num_rows", nullptr, (EPropertyFlags)0x0010000000000001, UE4CodeGen_Private::EPropertyGenFlags::Int, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AInvaderSpawner, num_rows), METADATA_PARAMS(Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_num_rows_MetaData, ARRAY_COUNT(Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_num_rows_MetaData)) };
	const UE4CodeGen_Private::FPropertyParamsBase* const Z_Construct_UClass_AInvaderSpawner_Statics::PropPointers[] = {
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_spawn_type,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_num_cols,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_num_rows,
	};
	const FCppClassTypeInfoStatic Z_Construct_UClass_AInvaderSpawner_Statics::StaticCppClassTypeInfo = {
		TCppClassTypeTraits<AInvaderSpawner>::IsAbstract,
	};
	const UE4CodeGen_Private::FClassParams Z_Construct_UClass_AInvaderSpawner_Statics::ClassParams = {
		&AInvaderSpawner::StaticClass,
		nullptr,
		&StaticCppClassTypeInfo,
		DependentSingletons,
		nullptr,
		Z_Construct_UClass_AInvaderSpawner_Statics::PropPointers,
		nullptr,
		ARRAY_COUNT(DependentSingletons),
		0,
		ARRAY_COUNT(Z_Construct_UClass_AInvaderSpawner_Statics::PropPointers),
		0,
		0x009000A0u,
		METADATA_PARAMS(Z_Construct_UClass_AInvaderSpawner_Statics::Class_MetaDataParams, ARRAY_COUNT(Z_Construct_UClass_AInvaderSpawner_Statics::Class_MetaDataParams))
	};
	UClass* Z_Construct_UClass_AInvaderSpawner()
	{
		static UClass* OuterClass = nullptr;
		if (!OuterClass)
		{
			UE4CodeGen_Private::ConstructUClass(OuterClass, Z_Construct_UClass_AInvaderSpawner_Statics::ClassParams);
		}
		return OuterClass;
	}
	IMPLEMENT_CLASS(AInvaderSpawner, 1207551663);
	template<> SPACEINVADERS_UNREAL_API UClass* StaticClass<AInvaderSpawner>()
	{
		return AInvaderSpawner::StaticClass();
	}
	static FCompiledInDefer Z_CompiledInDefer_UClass_AInvaderSpawner(Z_Construct_UClass_AInvaderSpawner, &AInvaderSpawner::StaticClass, TEXT("/Script/SpaceInvaders_Unreal"), TEXT("AInvaderSpawner"), false, nullptr, nullptr, nullptr);
	DEFINE_VTABLE_PTR_HELPER_CTOR(AInvaderSpawner);
PRAGMA_ENABLE_DEPRECATION_WARNINGS
#ifdef _MSC_VER
#pragma warning (pop)
#endif
