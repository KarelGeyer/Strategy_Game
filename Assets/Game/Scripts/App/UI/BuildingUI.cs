using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BuildingUI : UIInteractionBaseObject, IBuildingUiPanel
{
	[SerializeField]
	[Tooltip("Building that has last registered a click event, this field serves as a source of display data")]
	private WorkBuilding m_currentBuilding;

	[Header("Material")]
	[SerializeField]
	private TextMeshProUGUI m_materialAmount;

	[SerializeField]
	private TextMeshProUGUI m_materialType;

	[Header("NPC's")]
	[SerializeField]
	[Tooltip("Provides basic working speed")]
	private TextMeshProUGUI m_amountOfWorkers;

	[SerializeField]
	[Tooltip("Neccessary in some buildings, in others provides increased working speed")]
	private TextMeshProUGUI m_amountOfSpecialists;

	[SerializeField]
	[Tooltip("Managers presence provides speed boost to other workers, usually has a gap of 1 but might serve as a basic worker")]
	private TextMeshProUGUI m_amountOfManagers;

	public void DisplayUI(BuildingUIModel data, WorkBuilding building)
	{
		if (UI_Manager.Instance.CanPlayerInteractWithUi)
		{
			gameObject.SetActive(true);
			UpdateUI(data);
			m_currentBuilding = building;
		}
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
