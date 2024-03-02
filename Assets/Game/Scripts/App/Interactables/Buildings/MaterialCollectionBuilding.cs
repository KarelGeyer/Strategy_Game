using System.Collections;
using System.Collections.Generic;
using Assets.Game.Scripts.Enums;
using UnityEngine;

public class MaterialCollectionBuilding : WorkBuilding, IMaterialCollectionBuilding
{
	[Header("Materials")]
	[SerializeField]
	[Tooltip("List of all resources assigned to the building")]
	private List<GameObject> m_materialDeposits;

	[SerializeField]
	private MaterialType m_collectionType;

	private MaterialsStorage m_materials;

	private void Awake()
	{
		m_materials = GameObject.FindGameObjectWithTag(Constants.GAME_OBJECT_MATERIALS).GetComponent<MaterialsStorage>();
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

	/// <summary>
	/// Method responsible for depleting materials assigned to the building.
	/// In order to mine, bulding needs NPC's adding total strength to it.
	/// If no material deposits are around the building, it serves no purpose.
	/// Methods calls:
	/// <list type="bullet">
	/// <item><see cref="Building.GetTotalStrength"/></item>
	/// <item><see cref="MaterialsStorage.IncreaseMaterialAmount(MaterialType, int)"/></item>
	/// <item><see cref="MaterialDeposit.ReduceDepositBy(int)"/></item>
	/// </list>
	/// </summary>
	private void MineMaterial()
	{
		if (CurentlyWorkingEmployees.Count > 0 && m_materialDeposits.Count > 0)
		{
			GameObject currentDeposit = m_materialDeposits.Find(depositObject => depositObject.GetComponent<MaterialDeposit>().DepositAmount > 0);

			int currentDepositAmount = currentDeposit.GetComponent<MaterialDeposit>().DepositAmount;
			int totalStrength = GetTotalStrength();

			if (currentDepositAmount < totalStrength)
			{
				m_materials.UpdateMaterialAmount(m_collectionType, currentDepositAmount, UpdateType.Increase);
				currentDeposit.GetComponent<MaterialDeposit>().ReduceDepositBy(currentDepositAmount);
				m_materialDeposits.Remove(currentDeposit);
				if (m_materialDeposits.Count == 0)
				{
					CancelInvoke(nameof(MineMaterial));
				}
			}
			else
			{
				m_materials.UpdateMaterialAmount(m_collectionType, totalStrength, UpdateType.Increase);
				currentDeposit.GetComponent<MaterialDeposit>().ReduceDepositBy(totalStrength);
			}
		}
	}

	/// <summary>
	/// Assignes deposits found around the building in given radious when building is spawned.
	/// </summary>
	private void AssignDeposits()
	{
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, Constants.BUILDING_MATERIAL_COLLECTION_RADIUS, 1 << 6);
		foreach (Collider collider in hitColliders)
		{
			if (collider.gameObject.tag == m_collectionType.ToString())
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
