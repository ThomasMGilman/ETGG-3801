// Fill out your copyright notice in the Description page of Project Settings.

using UnrealBuildTool;
using System.Collections.Generic;

public class SpaceInvaders_UnrealEditorTarget : TargetRules
{
	public SpaceInvaders_UnrealEditorTarget(TargetInfo Target) : base(Target)
	{
		Type = TargetType.Editor;

		ExtraModuleNames.AddRange( new string[] { "SpaceInvaders_Unreal" } );
	}
}
