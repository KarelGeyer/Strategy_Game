using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWorkBuilding : IBuilding
{
	/// <summary>
	/// Asks <see cref="NPCManager"/> to assign new NPC to this building. <see cref="NPCManager.AskForWorker(WorkBuilding)"/>
	/// </summary>
	void AskForWorker();

	void AcceptWorker(NPC citizen);

	/// <summary>
	/// Defines building building behavior when amount of employees is reduced and responsible for
	/// letting other entities (e.g. NPC manager or UI) know about NPC being released from its working routine at this building.
	/// Method calls:
	/// <list type="bullet">
	/// <item><see cref="NPCManager.UnemployCitizen(NPC)"/></item>
	/// <item><see cref="BuildingUI.UpdateAmountOfWorkers(int)"/></item>
	/// </list>
	/// </summary>
	void FireEmployee();
}
