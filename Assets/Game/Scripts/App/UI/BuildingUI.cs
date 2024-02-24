using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildingUI : UI_Base_Object, IBuildingUiPanel
{
	[SerializeField]
	private TextMeshProUGUI m_materialAmount;

	[SerializeField]
	private TextMeshProUGUI m_amountOfWorkers;

	[SerializeField]
	private TextMeshProUGUI m_amountOfSpecialists;

	[SerializeField]
	private TextMeshProUGUI m_amountOfManagers;

	[SerializeField]
	private WorkBuilding m_currentBuilding;

	public void DisplayUI(BuildingUIModel data, WorkBuilding building)
	{
		if (GameManager.Instance.CanPlayerInteract)
		{
			gameObject.SetActive(true);
			UpdateUI(data);
			m_currentBuilding = building;
		}
	}

	public void CloseUI()
	{
		gameObject.SetActive(false);
	}

	public void UpdateUI(BuildingUIModel model)
	{
		m_materialAmount.text = model.AmountOfMaterial.ToString();
		m_amountOfWorkers.text = model.AmountOfWorkers.ToString();
		m_amountOfSpecialists.text = model.AmountOfSpecialists.ToString();
		m_amountOfManagers.text = model.AmountOfManagers.ToString();
	}

	public void UpdateAmountOfMaterialText(int amountOfMaterial)
	{
		m_materialAmount.text = amountOfMaterial.ToString();
	}

	public void UpdateAmountOfWorkers(int amountOfWorkers)
	{
		m_amountOfWorkers.text = amountOfWorkers.ToString();
	}

	public void TriggerAskForWorker()
	{
		m_currentBuilding.AskForWorker();
	}

	public void TriggerRemoveWorker()
	{
		m_currentBuilding.FireEmployee();
	}
}
