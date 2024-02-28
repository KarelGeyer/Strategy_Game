using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
	private static UI_Manager instance;
	public static UI_Manager Instance
	{
		get { return instance; }
	}

	private bool m_CanPlayerInteractWithUi = false;
	public bool CanPlayerInteractWithUi
	{
		get { return m_CanPlayerInteractWithUi; }
		set { m_CanPlayerInteractWithUi = value; }
	}

	[SerializeField]
	[Tooltip("All UI is drawn on this element")]
	private GameObject m_canvas;

	[SerializeField]
	[Tooltip("Displays information about a material deposit that has been last clicked on")]
	private MaterialDepositUi m_materialDepositUi;

	[SerializeField]
	[Tooltip("Displays information about a building that has been last clicked on")]
	private BuildingUI m_buildingUI;

	[SerializeField]
	[Tooltip("Displays materials amount at the top of the screen")]
	private MaterialStorageUi m_materialStorageUI;

	private void Awake()
	{
		ManageInstance();
	}

	private void ManageInstance()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
			Destroy(gameObject);
	}

	public MaterialDepositUi GetMaterialDepositUi()
	{
		return m_materialDepositUi;
	}

	public BuildingUI GetBuildingUI()
	{
		return m_buildingUI;
	}

	public MaterialStorageUi GetStorageUI()
	{
		return m_materialStorageUI;
	}
}
