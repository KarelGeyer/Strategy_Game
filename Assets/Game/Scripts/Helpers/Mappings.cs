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

	/// <summary>
	/// Responsible for assigned costs to a correct material and returning this data as a list
	/// </summary>
	/// <param name="costs"></param>
	/// <returns>correctly paired costs with their respective materials</returns>
	public static List<MaterialCost> GetBuildingsCost(List<int> costs)
	{
		List<MaterialCost> costList = new List<MaterialCost>();

		for (int i = 0; i < costs.Count; i++)
		{
			MaterialCost cost = new() { Cost = costs[i] };
			switch (i)
			{
				case 0:
					cost.MaterialType = MaterialType.Wood;
					break;
				case 1:
					cost.MaterialType = MaterialType.Rock;
					break;
				case 2:
					cost.MaterialType = MaterialType.Silver;
					break;
				case 3:
					cost.MaterialType = MaterialType.Gems;
					break;
			}
			costList.Add(cost);
		}

		return costList;
	}
}
