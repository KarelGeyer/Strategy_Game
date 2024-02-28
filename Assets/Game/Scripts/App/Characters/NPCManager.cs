using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
	private static NPCManager instance;
	public static NPCManager Instance
	{
		get { return instance; }
	}

	[SerializeField]
	private List<NPC> m_allCitizens;

	[SerializeField]
	private List<NPC> m_allUnemployedAdults;

	void Awake()
	{
		ManageInstance();
		RetrieveAllCitizens();
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

	/// <summary>
	/// find's all controllable NPC's and assigned them to the list
	/// </summary>
	private void RetrieveAllCitizens()
	{
		List<NPC> citizens = GetComponentsInChildren<NPC>().ToList();
		foreach (NPC citizen in citizens)
		{
			m_allCitizens.Add(citizen);

			if (citizen.IsAdult && !citizen.IsEmployed)
				m_allUnemployedAdults.Add(citizen);
		}
	}

	/// <summary>
	/// Adds a NPC to a workplace to start a working routine. Workplace building will increase its NPC list and once NPC
	/// Arrives at its location, its working routine will start.
	///	Calls following:
	/// <list type="bullet">
	/// <item><see cref="WorkBuilding.AcceptWorker(NPC)"/></item>
	/// <item><see cref="NPC.AssignWorkplace(Building)"/></item>
	/// </list>
	/// </summary>
	/// <param name="workPlace">Workbuilding for npc</param>
	private void EmployCitizen(WorkBuilding workPlace)
	{
		int randomIndex = Random.Range(0, m_allUnemployedAdults.Count);
		NPC citizen = m_allUnemployedAdults[randomIndex];

		workPlace.AcceptWorker(citizen);
		citizen.AssignWorkplace(workPlace);
		m_allUnemployedAdults.Remove(citizen);
	}

	/// <summary name="AddCitizen">
	/// Adds a new controllable NPC
	/// </summary>
	/// <param name="citizen">A NPC gameobject, that is to become a controllable NPC</param>
	public void AddCitizen(GameObject citizen)
	{
		m_allCitizens.Add(citizen.GetComponent<NPC>());
	}

	/// <inheritdoc cref="AddCitizen"/>
	/// <param name="citizen">A NPC component of a gameobject, that is to become a controllable NPC</param>
	public void AddCitizen(NPC citizen)
	{
		m_allCitizens.Add(citizen);
	}

	/// <summary>
	/// If there is an NPC that can be assigned to the building, it will assign an NPC to start its working routine there.
	/// Calls following:
	/// <list type="bullet">
	/// <item><see cref="EmployCitizen(WorkBuilding)"/></item>
	/// </list>
	/// </summary>
	/// <param name="workPlace">A workplace building</param>
	public void AskForWorker(WorkBuilding workPlace)
	{
		if (m_allUnemployedAdults.Count == 0)
			return;

		EmployCitizen(workPlace);
	}

	/// <summary>
	/// Triggers NPC's unemployment routine.
	/// Calls following:
	/// <list type="bullet">
	/// <item><see cref="NPC.BeFired"/></item>
	/// </list>
	/// </summary>
	/// <param name="citizen">A controllable NPC</param>
	public void UnemployCitizen(NPC citizen)
	{
		m_allUnemployedAdults.Add(citizen);
		citizen.BeFired();
	}
}
