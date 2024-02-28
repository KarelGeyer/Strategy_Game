using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMaterialCollectionBuilding : IWorkBuilding
{
	/// <returns>total current amount of minable materials around</returns>
	int GetTotalAmountOfDeposit();
}
