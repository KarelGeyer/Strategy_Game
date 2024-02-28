using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Building : Interactable, IBuilding
{
	[Header("NPC's")]
	[SerializeField]
	[Tooltip("NPC's that are frequently visiting this building to work")]
	protected List<NPC> m_assignedCitizens;

	[SerializeField]
	[Tooltip("NPC's that are currently working in the building")]
	protected List<NPC> m_currentlyPresentCitizens;

	[SerializeField]
	protected NPCManager m_npcManager;

	[Header("UI")]
	[SerializeField]
	protected BuildingUI m_buildingUI;

	void Start()
	{
		m_npcManager = NPCManager.Instance;
		m_buildingUI = UI_Manager.Instance.GetBuildingUI();
	}

	private void OnCollisionEnter(Collision collision)
	{
		ManageNPCEnter(collision.gameObject);
	}

	/// <summary>
	/// @protected.
	/// Defines how should the building behave when NPC collides with it.
	/// <list type="bullet">
	/// <item><see cref="IsAllowedToEnter"/></item>
	/// </list>
	/// </summary>
	/// <param name="gameObject">collision gameobject</param>
	protected virtual void ManageNPCEnter(GameObject gameObject)
	{
		bool isCitizen = gameObject.tag.Equals(Constants.NPC);
		if (isCitizen)
		{
			NPC citizen = gameObject.GetComponent<NPC>();
			if (IsAllowedToEnter(citizen))
			{
				m_currentlyPresentCitizens.Add(citizen);
				gameObject.SetActive(false);
			}
		}
	}

	/// <summary>
	/// @protected.
	/// Defines how should building behave, when NPC is leaving it
	/// </summary>
	/// <param name="employee">NPC that is leaving the building</param>
	protected virtual void ManageNPCLeave(NPC employee)
	{
		employee.gameObject.SetActive(true);
		m_currentlyPresentCitizens.Remove(employee);
	}

	protected virtual void DisplayUI() { }

	/// <summary>
	/// for information about strength, see <see cref="NPC.m_strength"/>
	/// </summary>
	/// <returns>Total strength of all currently working Npc's</returns>
	protected int GetTotalStrength()
	{
		int totalStrength = 0;
		foreach (NPC employee in m_currentlyPresentCitizens)
		{
			totalStrength += employee.Strength;
		}

		return totalStrength;
	}

	/// <summary>
	/// NPC is only allowed to enter if it can be found in assigned NPC's list <see cref="m_assignedCitizens"/>
	/// </summary>
	/// <param name="npc">NPC trying to enter</param>
	/// <returns>wheter or not NPC can enter the building</returns>
	private bool IsAllowedToEnter(NPC npc)
	{
		bool foundNpc = m_assignedCitizens.Find(assignedNpc => assignedNpc.Equals(npc));
		return foundNpc;
	}
}
