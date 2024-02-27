using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
	#region MATERIALS
	public const string MATERIAL_TYPE_SILVER = "Silver";
	public const string MATERIAL_TYPE_WOOD = "Wood";
	public const string MATERIAL_TYPE_GEMS = "Gems";
	public const string MATERIAL_TYPE_ROCK = "Rock";
	public const string MATERIAL_TYPE_FOOD = "Food";

	public const string MATERIAL_SIZE_LARGE = "large";
	public const string MATERIAL_SIZE_MEDIUM = "medium";
	public const string MATERIAL_SIZE_SMALL = "small";

	public const int MATERIAL_AMOUNT_LARGE = 50;
	public const int MATERIAL_AMOUNT_MEDIUM = 20;
	public const int MATERIAL_AMOUNT_SMALL = 10;
	#endregion

	#region BUILDINGS
	public const float BUILDING_MATERIAL_COLLECTION_RADIUS = 40f;
	#endregion

	#region NPCS
	public const string NPC = "NPC";
	public const int NPC_ADULT_AGE = 18;
	#endregion

	#region GAME_OBJECTS_NAMES
	public const string GAME_OBJECT_BUILDING_LEAVING_SPOT = "Leaving_Spot";
	public const string GAME_OBJECT_MATERIALS = "Materials";
	#endregion

	#region GAME_SETTINGS
	public const int REPEAT_TIME_INTERVAL_SHORT = 3;
	public const int REPEAT_TIME_INTERVAL_MEDIUM = 10;
	public const int REPEAT_TIME_INTERVAL_LONG = 30;
	public const int REPEAT_TIME_INTERVAL_VERY_LONG = 100;

	public const string AXIS_HORIZONTAL = "Horizontal";
	public const string AXIS_VERTICAL = "Vertical";

	public const string INTERACTION = "Interaction";
	#endregion
}
