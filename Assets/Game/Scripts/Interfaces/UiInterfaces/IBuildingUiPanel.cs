using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuildingUiPanel : IUiPanel<BuildingUIModel>
{
	void DisplayUI(BuildingUIModel data, WorkBuilding building);

	public void UpdateAmountOfMaterialText(int amountOfMaterial);

	public void UpdateAmountOfWorkers(int amountOfWorkers);

	public void TriggerAskForWorker();

	public void TriggerRemoveWorker();
}
