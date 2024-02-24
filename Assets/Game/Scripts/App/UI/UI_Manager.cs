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

	[SerializeField]
	private GameObject m_Canvas;

	[SerializeField]
	private MaterialDepositUi m_materialDepositUi;

	[SerializeField]
	private BuildingUI m_buildingUI;

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
}
