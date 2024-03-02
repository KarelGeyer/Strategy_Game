using System.Collections;
using System.Collections.Generic;

public static class Mappings
{
	/// <param name="type"><see cref="MaterialType"/></param>
	/// <returns>string representation of a <see cref="MaterialType"/> enum</returns>
	public static string MapMaterialTypeToString(MaterialType type)
	{
		string materialType = string.Empty;
		switch (type)
		{
			case MaterialType.Silver:
				materialType = Constants.MATERIAL_TYPE_SILVER;
				break;
			case MaterialType.Wood:
				materialType = Constants.MATERIAL_TYPE_WOOD;
				break;
			case MaterialType.Food:
				materialType = Constants.MATERIAL_TYPE_FOOD;
				break;
			case MaterialType.Rock:
				materialType = Constants.MATERIAL_TYPE_ROCK;
				break;
			case MaterialType.Gems:
				materialType = Constants.MATERIAL_TYPE_GEMS;
				break;
		}

		return materialType;
	}

	/// <param name="name"> Material deposit game object name</param>
	/// <returns><see cref="MaterialSize"/> based on object name provided as an argument</returns>
	public static MaterialSize MapMaterialNameToSize(string name)
	{
		MaterialSize size = new MaterialSize();

		if (name.Contains(Constants.MATERIAL_SIZE_LARGE))
			size = MaterialSize.Large;
		if (name.Contains(Constants.MATERIAL_SIZE_MEDIUM))
			size = MaterialSize.Medium;
		if (name.Contains(Constants.MATERIAL_SIZE_SMALL))
			size = MaterialSize.Small;

		return size;
	}

	/// <param name="size">Size of material</param>
	/// <returns>total deposit amount based on <see cref="MaterialSize"/> provided</returns>
	public static int MapMaterialSizeToDepositAmount(MaterialSize size)
	{
		int amount = 0;
		switch (size)
		{
			case MaterialSize.Large:
				amount = Constants.MATERIAL_AMOUNT_LARGE;
				break;
			case MaterialSize.Medium:
				amount = Constants.MATERIAL_AMOUNT_MEDIUM;
				break;
			case MaterialSize.Small:
				amount = Constants.MATERIAL_AMOUNT_SMALL;
				break;
		}

		return amount;
	}

	public static Dictionary<string, int> GetBuildingsCost(List<int> costs)
	{
		Dictionary<string, int> buildingCost = new Dictionary<string, int>();

		for (int i = 0; i < costs.Count; i++)
		{
			switch (costs[i])
			{
				case 0:
					buildingCost.Add("Rock", costs[i]);
					break;
				case 1:
					buildingCost.Add("Wood", costs[i]);
					break;
				case 2:
					buildingCost.Add("Steel", costs[i]);
					break;
				case 3:
					buildingCost.Add("Diamond", costs[i]);
					break;
			}
		}

		return buildingCost;
	}
}
