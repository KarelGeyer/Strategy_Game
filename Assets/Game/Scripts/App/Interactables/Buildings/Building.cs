using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Building : Interactable, IBuilding
{
	[SerializeField]
	protected List<NPC> m_assignedCitizens;

	[SerializeField]
	protected List<NPC> m_currentlyPresentCitizens;

	[SerializeField]
	protected BuildingUI m_buildingUI;

	[SerializeField]
	protected NPCManager m_npcManager;

	void Start()
	{
		m_buildingUI = UI_Manager.Instance.GetBuildingUI();
		m_npcManager = NPCManager.Instance;
	}

	void OnCollisionEnter(Collision collision)
	{
		ManageNPCEnter(collision.gameObject);
	}

	protected virtual void ManageNPCEnter(GameObject gameObject)
	{
		bool isCitizen = gameObject.tag.Equals(Constants.NPC);
		if (isCitizen)
		{
			m_currentlyPresentCitizens.Add(gameObject.GetComponent<NPC>());
			gameObject.SetActive(false);
		}
	}

	protected virtual void ManageNPCLeave(NPC employee)
	{
		employee.gameObject.SetActive(true);
		m_currentlyPresentCitizens.Remove(employee);
	}

	protected virtual void DisplayUI() { }

	protected int GetTotalStrength()
	{
		int totalStrength = 0;
		foreach (NPC employee in m_currentlyPresentCitizens)
		{
			totalStrength += employee.Strength;
		}

		return totalStrength;
	}
}
