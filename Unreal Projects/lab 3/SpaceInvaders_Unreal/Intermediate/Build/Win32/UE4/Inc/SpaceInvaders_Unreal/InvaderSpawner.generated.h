// Copyright 1998-2019 Epic Games, Inc. All Rights Reserved.
/*===========================================================================
	Generated code exported from UnrealHeaderTool.
	DO NOT modify this manually! Edit the corresponding .h files instead!
===========================================================================*/

#include "UObject/ObjectMacros.h"
#include "UObject/ScriptMacros.h"

PRAGMA_DISABLE_DEPRECATION_WARNINGS
#ifdef SPACEINVADERS_UNREAL_InvaderSpawner_generated_h
#error "InvaderSpawner.generated.h already included, missing '#pragma once' in InvaderSpawner.h"
#endif
#define SPACEINVADERS_UNREAL_InvaderSpawner_generated_h

#define SpaceInvaders_Unreal_Source_SpaceInvaders_Unreal_Public_InvaderSpawner_h_12_RPC_WRAPPERS \
 \
	DECLARE_FUNCTION(exechitWall) \
	{ \
		P_FINISH; \
		P_NATIVE_BEGIN; \
		P_THIS->hitWall(); \
		P_NATIVE_END; \
	}


#define SpaceInvaders_Unreal_Source_SpaceInvaders_Unreal_Public_InvaderSpawner_h_12_RPC_WRAPPERS_NO_PURE_DECLS \
 \
	DECLARE_FUNCTION(exechitWall) \
	{ \
		P_FINISH; \
		P_NATIVE_BEGIN; \
		P_THIS->hitWall(); \
		P_NATIVE_END; \
	}


#define SpaceInvaders_Unreal_Source_SpaceInvaders_Unreal_Public_InvaderSpawner_h_12_INCLASS_NO_PURE_DECLS \
private: \
	static void StaticRegisterNativesAInvaderSpawner(); \
	friend struct Z_Construct_UClass_AInvaderSpawner_Statics; \
public: \
	DECLARE_CLASS(AInvaderSpawner, AActor, COMPILED_IN_FLAGS(0), CASTCLASS_None, TEXT("/Script/SpaceInvaders_Unreal"), NO_API) \
	DECLARE_SERIALIZER(AInvaderSpawner)


#define SpaceInvaders_Unreal_Source_SpaceInvaders_Unreal_Public_InvaderSpawner_h_12_INCLASS \
private: \
	static void StaticRegisterNativesAInvaderSpawner(); \
	friend struct Z_Construct_UClass_AInvaderSpawner_Statics; \
public: \
	DECLARE_CLASS(AInvaderSpawner, AActor, COMPILED_IN_FLAGS(0), CASTCLASS_None, TEXT("/Script/SpaceInvaders_Unreal"), NO_API) \
	DECLARE_SERIALIZER(AInvaderSpawner)


#define SpaceInvaders_Unreal_Source_SpaceInvaders_Unreal_Public_InvaderSpawner_h_12_STANDARD_CONSTRUCTORS \
	/** Standard constructor, called after all reflected properties have been initialized */ \
	NO_API AInvaderSpawner(const FObjectInitializer& ObjectInitializer); \
	DEFINE_DEFAULT_OBJECT_INITIALIZER_CONSTRUCTOR_CALL(AInvaderSpawner) \
	DECLARE_VTABLE_PTR_HELPER_CTOR(NO_API, AInvaderSpawner); \
DEFINE_VTABLE_PTR_HELPER_CTOR_CALLER(AInvaderSpawner); \
private: \
	/** Private move- and copy-constructors, should never be used */ \
	NO_API AInvaderSpawner(AInvaderSpawner&&); \
	NO_API AInvaderSpawner(const AInvaderSpawner&); \
public:


#define SpaceInvaders_Unreal_Source_SpaceInvaders_Unreal_Public_InvaderSpawner_h_12_ENHANCED_CONSTRUCTORS \
private: \
	/** Private move- and copy-constructors, should never be used */ \
	NO_API AInvaderSpawner(AInvaderSpawner&&); \
	NO_API AInvaderSpawner(const AInvaderSpawner&); \
public: \
	DECLARE_VTABLE_PTR_HELPER_CTOR(NO_API, AInvaderSpawner); \
DEFINE_VTABLE_PTR_HELPER_CTOR_CALLER(AInvaderSpawner); \
	DEFINE_DEFAULT_CONSTRUCTOR_CALL(AInvaderSpawner)


#define SpaceInvaders_Unreal_Source_SpaceInvaders_Unreal_Public_InvaderSpawner_h_12_PRIVATE_PROPERTY_OFFSET
#define SpaceInvaders_Unreal_Source_SpaceInvaders_Unreal_Public_InvaderSpawner_h_9_PROLOG
#define SpaceInvaders_Unreal_Source_SpaceInvaders_Unreal_Public_InvaderSpawner_h_12_GENERATED_BODY_LEGACY \
PRAGMA_DISABLE_DEPRECATION_WARNINGS \
public: \
	SpaceInvaders_Unreal_Source_SpaceInvaders_Unreal_Public_InvaderSpawner_h_12_PRIVATE_PROPERTY_OFFSET \
	SpaceInvaders_Unreal_Source_SpaceInvaders_Unreal_Public_InvaderSpawner_h_12_RPC_WRAPPERS \
	SpaceInvaders_Unreal_Source_SpaceInvaders_Unreal_Public_InvaderSpawner_h_12_INCLASS \
	SpaceInvaders_Unreal_Source_SpaceInvaders_Unreal_Public_InvaderSpawner_h_12_STANDARD_CONSTRUCTORS \
public: \
PRAGMA_ENABLE_DEPRECATION_WARNINGS


#define SpaceInvaders_Unreal_Source_SpaceInvaders_Unreal_Public_InvaderSpawner_h_12_GENERATED_BODY \
PRAGMA_DISABLE_DEPRECATION_WARNINGS \
public: \
	SpaceInvaders_Unreal_Source_SpaceInvaders_Unreal_Public_InvaderSpawner_h_12_PRIVATE_PROPERTY_OFFSET \
	SpaceInvaders_Unreal_Source_SpaceInvaders_Unreal_Public_InvaderSpawner_h_12_RPC_WRAPPERS_NO_PURE_DECLS \
	SpaceInvaders_Unreal_Source_SpaceInvaders_Unreal_Public_InvaderSpawner_h_12_INCLASS_NO_PURE_DECLS \
	SpaceInvaders_Unreal_Source_SpaceInvaders_Unreal_Public_InvaderSpawner_h_12_ENHANCED_CONSTRUCTORS \
private: \
PRAGMA_ENABLE_DEPRECATION_WARNINGS


template<> SPACEINVADERS_UNREAL_API UClass* StaticClass<class AInvaderSpawner>();

#undef CURRENT_FILE_ID
#define CURRENT_FILE_ID SpaceInvaders_Unreal_Source_SpaceInvaders_Unreal_Public_InvaderSpawner_h


PRAGMA_ENABLE_DEPRECATION_WARNINGS
