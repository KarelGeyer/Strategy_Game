using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MaterialDeposit : Interactable
{
	[SerializeField]
	MaterialDepositUi m_depositUi;

	[SerializeField]
	MaterialType m_type;

	private int m_deposit;
	private MaterialSize m_size;

	#region Exposed privates
	public int DepositAmount
	{
		get { return m_deposit; }
	}
	#endregion

	private void Awake()
	{
		m_size = Mappings.MapMaterialNameToSize(transform.name);
		m_deposit = Mappings.MapMaterialSizeToDepositAmount(m_size);
	}

	private void Start()
	{
		m_depositUi = UI_Manager.Instance.GetMaterialDepositUi();
	}

	private void OnMouseDown()
	{
		DisplayUi();
	}

	#region Private
	private void DisplayUi()
	{
		MaterialDepositUIModel model =
			new()
			{
				Type = m_type,
				Amount = m_deposit,
				Description = "Description",
			};

		m_depositUi.DisplayUI(model, this);
	}

	private void DepleteMaterial()
	{
		gameObject.SetActive(false);
	}
	#endregion

	#region Public
	public void ReduceDepositBy(int amountToReduce)
	{
		m_deposit -= amountToReduce;
		if (m_deposit <= 0)
			DepleteMaterial();
	}
	#endregion
}
