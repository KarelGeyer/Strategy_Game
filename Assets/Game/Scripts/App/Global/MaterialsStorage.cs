using System.Collections;
using System.Collections.Generic;
using Assets.Game.Scripts.Enums;
using UnityEngine;

public class MaterialsStorage : MonoBehaviour
{
	[SerializeField]
	private MaterialStorageUi m_materialStorageUi;

	private int m_amountOfRock = 100;
	private int m_amountOfWood = 100;
	private int m_amountOfSilver = 100;
	private int m_amountOfGems = 10;
	private int m_amountOfFood = 100;

	private void Start()
	{
		m_materialStorageUi = UI_Manager.Instance.GetStorageUI();
		for (int i = 0; i < 5; i++)
		{
			MaterialStorageUIModel materialSModel = new() { MaterialType = (MaterialType)i, Value = 100 };
			m_materialStorageUi.UpdateUI(materialSModel);
		}
	}

	/// <summary>
	/// Based on material provided, it will update appropriate material amount by the provided value amount.
	/// Also responsible for calling the UI update:
	/// <list type="bullet">
	/// <item><see cref="MaterialStorageUi.UpdateUI(MaterialStorageUIModel)"/></item>
	/// </list>
	/// </summary>
	/// <param name="material">type of material to update</param>
	/// <param name="value">value affecting the material</param>
	/// <param name="type">Increase or decrease amount of material</param>
	public void UpdateMaterialAmount(MaterialType material, int value, UpdateType type)
	{
		int totalMaterialValue = 0;

		switch (material)
		{
			case MaterialType.Rock:
				m_amountOfRock = GetUpdatedValue(m_amountOfRock, value, type);
				totalMaterialValue = m_amountOfRock;
				break;
			case MaterialType.Wood:
				m_amountOfWood = GetUpdatedValue(m_amountOfWood, value, type);
				totalMaterialValue = m_amountOfWood;
				break;
			case MaterialType.Silver:
				m_amountOfSilver = GetUpdatedValue(m_amountOfSilver, value, type);
				totalMaterialValue = m_amountOfSilver;
				break;
			case MaterialType.Food:
				m_amountOfFood = GetUpdatedValue(m_amountOfFood, value, type);
				totalMaterialValue = m_amountOfFood;
				break;
			case MaterialType.Gems:
				m_amountOfGems = GetUpdatedValue(m_amountOfGems, value, type);
				totalMaterialValue = m_amountOfGems;
				break;
			default:
				print("No material has been added");
				break;
		}

		MaterialStorageUIModel materialSModel = new() { MaterialType = material, Value = totalMaterialValue, };
		m_materialStorageUi.UpdateUI(materialSModel);
	}

	/// <summary>
	/// Checks whether there is enough material on stock based on provided requirements
	/// </summary>
	/// <param name="shoppingList">List of requirements</param>
	/// <returns>true if there is enough materials</returns>
	public bool IsEnoughOnStock(List<MaterialCost> shoppingList)
	{
		bool isEnoughOnStock = true;
		foreach (MaterialCost cost in shoppingList)
		{
			int currentMaterialAmountInStorage = GetMaterialAmoutByMaterialType(cost.MaterialType);
			if (currentMaterialAmountInStorage < cost.Cost)
				isEnoughOnStock = false;
		}

		return isEnoughOnStock;
	}

	/// <inheritdoc cref="IsEnoughOnStock"/>
	public bool IsEnoughOnStock(MaterialCost cost)
	{
		int currentMaterialAmountInStorage = GetMaterialAmoutByMaterialType(cost.MaterialType);
		return currentMaterialAmountInStorage < cost.Cost;
	}

	public void SpendMaterialResources(List<MaterialCost> shoppingList)
	{
		foreach (MaterialCost cost in shoppingList)
		{
			UpdateMaterialAmount(cost.MaterialType, cost.Cost, UpdateType.Decrease);
		}
	}

	public void SpendMaterialResources(MaterialCost materialCost)
	{
		UpdateMaterialAmount(materialCost.MaterialType, materialCost.Cost, UpdateType.Decrease);
	}

	/// <summary>
	/// Converts Material type to a concrete material amount on storage
	/// </summary>
	/// <param name="material"></param>
	/// <returns>int for a specific material amount on storage</returns>
	private int GetMaterialAmoutByMaterialType(MaterialType material)
	{
		int amountOfMaterial = 0;
		switch (material)
		{
			case MaterialType.Wood:
				amountOfMaterial = m_amountOfWood;
				break;
			case MaterialType.Rock:
				amountOfMaterial = m_amountOfRock;
				break;
			case MaterialType.Food:
				amountOfMaterial = m_amountOfFood;
				break;
			case MaterialType.Silver:
				amountOfMaterial = m_amountOfSilver;
				break;
			case MaterialType.Gems:
				amountOfMaterial = m_amountOfGems;
				break;
		}

		return amountOfMaterial;
	}

	/// <param name="materialAmount"></param>
	/// <param name="value"></param>
	/// <param name="type"></param>
	/// <returns>Updated value of a material</returns>
	private int GetUpdatedValue(int materialAmount, int value, UpdateType type)
	{
		if (type == UpdateType.Increase)
		{
			return materialAmount += value;
		}
		else
		{
			return materialAmount -= value;
		}
	}
}
