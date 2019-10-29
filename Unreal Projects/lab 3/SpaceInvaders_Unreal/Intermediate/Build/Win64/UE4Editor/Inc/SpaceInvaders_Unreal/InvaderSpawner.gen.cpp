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
	SPACEINVADERS_UNREAL_API UFunction* Z_Construct_UFunction_AInvaderSpawner_hitWall();
	COREUOBJECT_API UClass* Z_Construct_UClass_UClass();
	ENGINE_API UClass* Z_Construct_UClass_AActor_NoRegister();
// End Cross Module References
	void AInvaderSpawner::StaticRegisterNativesAInvaderSpawner()
	{
		UClass* Class = AInvaderSpawner::StaticClass();
		static const FNameNativePtrPair Funcs[] = {
			{ "hitWall", &AInvaderSpawner::exechitWall },
		};
		FNativeFunctionRegistrar::RegisterFunctions(Class, Funcs, ARRAY_COUNT(Funcs));
	}
	struct Z_Construct_UFunction_AInvaderSpawner_hitWall_Statics
	{
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Function_MetaDataParams[];
#endif
		static const UE4CodeGen_Private::FFunctionParams FuncParams;
	};
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UFunction_AInvaderSpawner_hitWall_Statics::Function_MetaDataParams[] = {
		{ "Category", "wallCollisionHandle" },
		{ "ModuleRelativePath", "Public/InvaderSpawner.h" },
	};
#endif
	const UE4CodeGen_Private::FFunctionParams Z_Construct_UFunction_AInvaderSpawner_hitWall_Statics::FuncParams = { (UObject*(*)())Z_Construct_UClass_AInvaderSpawner, nullptr, "hitWall", nullptr, nullptr, 0, nullptr, 0, RF_Public|RF_Transient|RF_MarkAsNative, (EFunctionFlags)0x04020401, 0, 0, METADATA_PARAMS(Z_Construct_UFunction_AInvaderSpawner_hitWall_Statics::Function_MetaDataParams, ARRAY_COUNT(Z_Construct_UFunction_AInvaderSpawner_hitWall_Statics::Function_MetaDataParams)) };
	UFunction* Z_Construct_UFunction_AInvaderSpawner_hitWall()
	{
		static UFunction* ReturnFunction = nullptr;
		if (!ReturnFunction)
		{
			UE4CodeGen_Private::ConstructUFunction(ReturnFunction, Z_Construct_UFunction_AInvaderSpawner_hitWall_Statics::FuncParams);
		}
		return ReturnFunction;
	}
	UClass* Z_Construct_UClass_AInvaderSpawner_NoRegister()
	{
		return AInvaderSpawner::StaticClass();
	}
	struct Z_Construct_UClass_AInvaderSpawner_Statics
	{
		static UObject* (*const DependentSingletons[])();
		static const FClassFunctionLinkInfo FuncInfo[];
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam Class_MetaDataParams[];
#endif
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_spawn_type_MetaData[];
#endif
		static const UE4CodeGen_Private::FClassPropertyParams NewProp_spawn_type;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_forward_time_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_forward_time;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_move_speed_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_move_speed;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_colSpacing_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_colSpacing;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_num_cols_MetaData[];
#endif
		static const UE4CodeGen_Private::FIntPropertyParams NewProp_num_cols;
#if WITH_METADATA
		static const UE4CodeGen_Private::FMetaDataPairParam NewProp_rowSpacing_MetaData[];
#endif
		static const UE4CodeGen_Private::FFloatPropertyParams NewProp_rowSpacing;
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
	const FClassFunctionLinkInfo Z_Construct_UClass_AInvaderSpawner_Statics::FuncInfo[] = {
		{ &Z_Construct_UFunction_AInvaderSpawner_hitWall, "hitWall" }, // 1967886003
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
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_forward_time_MetaData[] = {
		{ "Category", "InvaderVariables" },
		{ "Comment", "//The max time in seconds to move forward after colliding with a wall\n" },
		{ "ModuleRelativePath", "Public/InvaderSpawner.h" },
		{ "ToolTip", "The max time in seconds to move forward after colliding with a wall" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_forward_time = { "forward_time", nullptr, (EPropertyFlags)0x0010000000000001, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AInvaderSpawner, forward_time), METADATA_PARAMS(Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_forward_time_MetaData, ARRAY_COUNT(Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_forward_time_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_move_speed_MetaData[] = {
		{ "Category", "InvaderVariables" },
		{ "Comment", "//Speed for the invader movement\n" },
		{ "ModuleRelativePath", "Public/InvaderSpawner.h" },
		{ "ToolTip", "Speed for the invader movement" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_move_speed = { "move_speed", nullptr, (EPropertyFlags)0x0010000000000001, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AInvaderSpawner, move_speed), METADATA_PARAMS(Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_move_speed_MetaData, ARRAY_COUNT(Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_move_speed_MetaData)) };
#if WITH_METADATA
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_colSpacing_MetaData[] = {
		{ "Category", "InvaderVariables" },
		{ "Comment", "//The spacing amount between invaders per column\n" },
		{ "ModuleRelativePath", "Public/InvaderSpawner.h" },
		{ "ToolTip", "The spacing amount between invaders per column" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_colSpacing = { "colSpacing", nullptr, (EPropertyFlags)0x0010000000000001, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AInvaderSpawner, colSpacing), METADATA_PARAMS(Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_colSpacing_MetaData, ARRAY_COUNT(Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_colSpacing_MetaData)) };
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
	const UE4CodeGen_Private::FMetaDataPairParam Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_rowSpacing_MetaData[] = {
		{ "Category", "InvaderVariables" },
		{ "Comment", "//The spacing amount between invaders per row\n" },
		{ "ModuleRelativePath", "Public/InvaderSpawner.h" },
		{ "ToolTip", "The spacing amount between invaders per row" },
	};
#endif
	const UE4CodeGen_Private::FFloatPropertyParams Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_rowSpacing = { "rowSpacing", nullptr, (EPropertyFlags)0x0010000000000001, UE4CodeGen_Private::EPropertyGenFlags::Float, RF_Public|RF_Transient|RF_MarkAsNative, 1, STRUCT_OFFSET(AInvaderSpawner, rowSpacing), METADATA_PARAMS(Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_rowSpacing_MetaData, ARRAY_COUNT(Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_rowSpacing_MetaData)) };
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
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_forward_time,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_move_speed,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_colSpacing,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_num_cols,
		(const UE4CodeGen_Private::FPropertyParamsBase*)&Z_Construct_UClass_AInvaderSpawner_Statics::NewProp_rowSpacing,
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
		FuncInfo,
		Z_Construct_UClass_AInvaderSpawner_Statics::PropPointers,
		nullptr,
		ARRAY_COUNT(DependentSingletons),
		ARRAY_COUNT(FuncInfo),
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
	IMPLEMENT_CLASS(AInvaderSpawner, 2957119722);
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
