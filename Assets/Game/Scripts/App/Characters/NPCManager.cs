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

	private void EmployCitizen(WorkBuilding workPlace)
	{
		int randomIndex = Random.Range(0, m_allUnemployedAdults.Count);
		NPC citizen = m_allUnemployedAdults[randomIndex];

		workPlace.AcceptWorker(citizen);
		citizen.AssignWorkplace(workPlace);
		m_allUnemployedAdults.Remove(citizen);
	}

	public void AddCitizen(GameObject citizen)
	{
		m_allCitizens.Add(citizen.GetComponent<NPC>());
	}

	public void AddCitizen(NPC citizen)
	{
		m_allCitizens.Add(citizen);
	}

	public void AskForWorker(WorkBuilding workPlace)
	{
		if (m_allUnemployedAdults.Count == 0)
			return;

		EmployCitizen(workPlace);
	}

	public void UnemployCitizen(NPC citizen)
	{
		m_allUnemployedAdults.Add(citizen);
		citizen.BeFired();
	}
}
