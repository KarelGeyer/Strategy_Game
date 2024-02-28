using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Assertions.Must;

public class NPC : MonoBehaviour
{
	[SerializeField]
	[Range(0, 90)]
	private int m_age = 0;

	[SerializeField]
	[Tooltip("Place to go at 7 am in the morning")]
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

	/// <summary>
	/// Logic for NPC's behavior if it does not have a work assigned
	/// </summary>
	private void WaitForEmployment()
	{
		GameObject nearestPub = GameObject.Find("pub");
		SetNavigationGoal(nearestPub.transform.position);
	}

	/// <summary>
	/// Assigns a target location for NPC to go
	/// </summary>
	public void SetNavigationGoal(Vector3 position)
	{
		if (!gameObject.activeInHierarchy)
			gameObject.SetActive(true);

		m_agent.destination = position;
	}

	/// <summary>
	/// Assigns a workplace object building for the NPC. NPC will start a working routine based on assigned building.
	/// </summary>
	public void AssignWorkplace(Building building)
	{
		m_workPlace = building;
		SetNavigationGoal(m_workPlace.gameObject.transform.position);
		m_isEmployed = true;
	}

	/// <summary>
	/// Releases NPC from its working routine and starts its wait for employment behavior routine.
	/// <list type="bullet">
	/// <see cref="WaitForEmployment"/>
	/// </list>
	/// </summary>
	public void BeFired()
	{
		m_isEmployed = false;
		m_workPlace = null;
		WaitForEmployment();
	}
}
