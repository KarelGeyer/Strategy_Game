using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkBuilding : Building, IWorkBuilding
{
	protected List<NPC> Employees
	{
		get { return m_assignedCitizens; }
	}
	protected List<NPC> CurentlyWorkingEmployees
	{
		get { return m_currentlyPresentCitizens; }
	}

	protected override void DisplayUI() { }

	#region PUBLIC
	public void AskForWorker()
	{
		m_npcManager.AskForWorker(this);
	}

	public void AcceptWorker(NPC citizen)
	{
		Employees.Add(citizen);
		m_buildingUI.UpdateAmountOfWorkers(Employees.Count);
	}

	public void FireEmployee()
	{
		if (Employees.Count == 0)
			return;

		int randomIndex = Random.Range(0, Employees.Count);
		NPC citizen = Employees[randomIndex];

		NPC employeeFoundInBuilding = CurentlyWorkingEmployees.Find(x => x.Equals(citizen));
		bool isEmployeeInBuilding = employeeFoundInBuilding != null;

		if (isEmployeeInBuilding)
		{
			CurentlyWorkingEmployees.Remove(citizen);
			var leavingPosition = transform.Find(Constants.GAME_OBJECT_BUILDING_LEAVING_SPOT);

			citizen.transform.position = leavingPosition.position;
		}

		Employees.Remove(citizen);
		m_npcManager.UnemployCitizen(citizen);
		m_buildingUI.UpdateAmountOfWorkers(Employees.Count);
		ManageNPCLeave(citizen);
	}
	#endregion
}
