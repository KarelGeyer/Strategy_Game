using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialsStorage : MonoBehaviour
{
	[SerializeField]
	private MaterialStorageUi m_materialStorage;

	private int m_amountOfRock = 0;
	private int m_amountOfWood = 0;
	private int m_amountOfSilver = 0;
	private int m_amountOfGems = 0;
	private int m_amountOfFood = 0;

	public int AmountOfRock
	{
		get { return m_amountOfRock; }
	}

	public int AmountOfWood
	{
		get { return m_amountOfWood; }
	}

	public int AmountOfSilver
	{
		get { return m_amountOfSilver; }
	}

	public int AmountOfGems
	{
		get { return m_amountOfGems; }
	}

	public int AmountOfFood
	{
		get { return m_amountOfFood; }
	}

	private void Start()
	{
		m_materialStorage = UI_Manager.Instance.GetStorageUI();
	}

	public void IncreaseMaterialAmount(MaterialType material, int value)
	{
		int totalMaterialValue = 0;

		switch (material)
		{
			case MaterialType.Rock:
				m_amountOfRock += value;
				totalMaterialValue = m_amountOfRock;
				break;
			case MaterialType.Wood:
				m_amountOfWood += value;
				totalMaterialValue = m_amountOfWood;
				break;
			case MaterialType.Silver:
				m_amountOfSilver += value;
				totalMaterialValue = m_amountOfSilver;
				break;
			case MaterialType.Food:
				m_amountOfFood += value;
				totalMaterialValue = m_amountOfFood;
				break;
			case MaterialType.Gems:
				m_amountOfGems += value;
				totalMaterialValue = m_amountOfGems;
				break;
			default:
				print("No material has been added");
				break;
		}

		MaterialStorageUIModel materialStModel = new() { MaterialType = material, Value = totalMaterialValue, };
		m_materialStorage.UpdateUI(materialStModel);
	}
}