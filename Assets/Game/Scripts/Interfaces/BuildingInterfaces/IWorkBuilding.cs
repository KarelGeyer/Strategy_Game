using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWorkBuilding : IBuilding
{
	void AskForWorker();

	void AcceptWorker(NPC citizen);

	void FireEmployee();
}
