using System.Collections;
using System.Collections.Generic;

public static class Mappings
{
	public static string MapMaterialTypeToString(MaterialType type)
	{
		string materialType = string.Empty;
		switch (type)
		{
			case MaterialType.Steel:
				materialType = Constants.MATERIAL_TYPE_STEEL;
				break;
			case MaterialType.Wood:
				materialType = Constants.MATERIAL_TYPE_WOOD;
				break;
			case MaterialType.Coal:
				materialType = Constants.MATERIAL_TYPE_COAL;
				break;
			case MaterialType.Rock:
				materialType = Constants.MATERIAL_TYPE_ROCK;
				break;
		}
		return materialType;
	}

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
}
