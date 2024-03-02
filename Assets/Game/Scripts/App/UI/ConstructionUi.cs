using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionUi : UIInteractionBaseObject
{
	[SerializeField]
	List<GameObject> constructionSections;

	[SerializeField]
	GameObject newObject;

	public LayerMask layersToHit;

	private void Start()
	{
		constructionSections[0].SetActive(true);
	}

	public void DisplayUI()
	{
		if (UI_Manager.Instance.CanPlayerInteractWithUi)
		{
			gameObject.SetActive(true);
		}
	}

	public override void CloseUI()
	{
		UI_Manager.Instance.CanPlayerInteractWithUi = true;
		UI_Manager.Instance.GetControlPanelUI().gameObject.SetActive(true);
		base.CloseUI();
	}

	/// <summary>
	/// Display a specific child UI section
	/// </summary>
	/// <param name="section"></param>
	public void DisplaySection(string section)
	{
		foreach (GameObject constructionSection in constructionSections)
		{
			if (constructionSection.activeInHierarchy)
				constructionSection.SetActive(false);
		}

		FindSection(section).SetActive(true);
	}

	/// <summary>
	/// Find a children represeting a section of buttons
	/// </summary>
	/// <param name="soughtSection"></param>
	/// <returns>A child UI section</returns>
	public GameObject FindSection(string soughtSection)
	{
		return constructionSections.Find(section => section.name.Equals(soughtSection));
	}

	/// <summary>
	/// Responsible for creating a new <see cref="ConstructionSpawn"/> if there is enough materials for it
	/// </summary>
	/// <param name="gameObject">A building prefab, that will server as a template for <see cref="ConstructionSpawn"/></param>
	public void SpawnBuilding(GameObject gameObject)
	{
		Building building = gameObject.GetComponent<Building>();

		if (building != null)
		{
			MaterialsStorage materialsStorage = GameObject.FindGameObjectWithTag(Constants.GAME_OBJECT_MATERIALS).GetComponent<MaterialsStorage>();
			bool canBuild = materialsStorage.IsEnoughOnStock(building.GetCostList());

			if (canBuild)
			{
				GameObject construction = new GameObject(Constants.GAME_OBJECT_CONSTRUCTION);
				ConstructionSpawn constructionSpawn = construction.AddComponent<ConstructionSpawn>();
				constructionSpawn.SetBuilding(building);
				Instantiate(construction);
				base.CloseUI();
			}
		}
	}
}
