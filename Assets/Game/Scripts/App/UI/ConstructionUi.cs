using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionUi : UIInteractionBaseObject
{
	[SerializeField]
	List<GameObject> constructionSections;

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

	public void DisplaySection(string section)
	{
		foreach (GameObject constructionSection in constructionSections)
		{
			if (constructionSection.activeInHierarchy)
				constructionSection.SetActive(false);
		}

		FindSection(section).SetActive(true);
	}

	public GameObject FindSection(string soughtSection)
	{
		return constructionSections.Find(section => section.name.Equals(soughtSection));
	}
}
