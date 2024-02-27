using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions.Must;

public class NPC : MonoBehaviour
{
	[SerializeField]
	private int m_age = 0;

	[SerializeField]
	private Building m_workPlace;

	[SerializeField]
	private Building m_home;

	private NavMeshAgent m_agent;
	private bool m_isEmployed;

	private int m_strength = 3;

	#region SETTERS & GETTERS
	public int Strength
	{
		get { return m_strength; }
	}

	public bool IsEmployed
	{
		get { return m_isEmployed; }
	}

	public bool IsAdult
	{
		get { return m_age >= Constants.NPC_ADULT_AGE; }
	}
	#endregion

	private void Awake()
	{
		AssignAge();
	}

	private void Start()
	{
		m_agent = GetComponent<NavMeshAgent>();
	}

	private void AssignAge()
	{
		m_age = 18;
	}

	private void WaitForEmployment()
	{
		GameObject nearestPub = GameObject.Find("pub");
		SetNavigationGoal(nearestPub.transform.position);
	}

	public void SetNavigationGoal(Vector3 position)
	{
		if (!gameObject.activeInHierarchy)
			gameObject.SetActive(true);

		m_agent.destination = position;
	}

	public void AssignWorkplace(Building building)
	{
		m_workPlace = building;
		SetNavigationGoal(m_workPlace.gameObject.transform.position);
		m_isEmployed = true;
	}

	public void BeFired()
	{
		m_isEmployed = false;
		m_workPlace = null;
		WaitForEmployment();
	}
}
