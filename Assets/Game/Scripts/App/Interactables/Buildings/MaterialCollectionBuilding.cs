using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialCollectionBuilding : WorkBuilding, IMaterialCollectionBuilding
{
	[SerializeField]
	private List<GameObject> m_materialDeposits;

	private Materials m_materials;
	private string m_collectionType = Constants.MATERIAL_TYPE_ROCK;

	private void Awake()
	{
		m_materials = GameObject.FindGameObjectWithTag(Constants.GAME_OBJECT_MATERIALS).GetComponent<Materials>();
		AssignDeposits();
	}

	void Start()
	{
		InvokeRepeating(nameof(MineMaterial), 1f, 3f);
	}

	protected override void OnInteract()
	{
		DisplayUI();
	}

	private void MineMaterial()
	{
		if (CurentlyWorkingEmployees.Count > 0 && m_materialDeposits.Count > 0)
		{
			GameObject currentDeposit = m_materialDeposits.Find(depositObject => depositObject.GetComponent<MaterialDeposit>().DepositAmount > 0);

			int currentDepositAmount = currentDeposit.GetComponent<MaterialDeposit>().DepositAmount;
			int totalStrength = GetTotalStrength();

			if (currentDepositAmount < totalStrength)
			{
				m_materials.AmountOfRock += currentDepositAmount;

				currentDeposit.GetComponent<MaterialDeposit>().ReduceDepositBy(currentDepositAmount);
				m_materialDeposits.Remove(currentDeposit);
				if (m_materialDeposits.Count == 0)
				{
					CancelInvoke(nameof(MineMaterial));
				}
			}
			else
			{
				m_materials.AmountOfRock += totalStrength;
				currentDeposit.GetComponent<MaterialDeposit>().ReduceDepositBy(totalStrength);
			}

			m_buildingUI.UpdateAmountOfMaterialText(GetTotalAmountOfDeposit());
		}
	}

	private void AssignDeposits()
	{
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, Constants.BUILDING_MATERIAL_COLLECTION_RADIUS, 1 << 6);
		foreach (Collider collider in hitColliders)
		{
			if (collider.gameObject.tag.Equals(m_collectionType))
			{
				GameObject depositObject = collider.gameObject;
				m_materialDeposits.Add(depositObject);
			}
		}
	}

	protected override void DisplayUI()
	{
		BuildingUIModel data = new() { AmountOfMaterial = GetTotalAmountOfDeposit(), AmountOfWorkers = Employees.Count };
		m_buildingUI.DisplayUI(data, this);
	}

	public int GetTotalAmountOfDeposit()
	{
		int amount = 0;
		foreach (GameObject depositObject in m_materialDeposits)
		{
			MaterialDeposit deposit = depositObject.GetComponent<MaterialDeposit>();
			amount += deposit.DepositAmount;
		}

		return amount;
	}
}
