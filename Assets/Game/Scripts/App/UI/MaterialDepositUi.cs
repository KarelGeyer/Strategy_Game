using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class MaterialDepositUi : UIInteractionBaseObject, IUiPanel<MaterialDepositUIModel>
{
	[SerializeField]
	private TextMeshProUGUI m_type;

	[SerializeField]
	private TextMeshProUGUI m_amount;

	[SerializeField]
	private TextMeshProUGUI m_description;

	[SerializeField]
	private MaterialDeposit m_currentMaterialDeposit;

	public void DisplayUI(MaterialDepositUIModel data, MaterialDeposit deposit)
	{
		if (UI_Manager.Instance.CanPlayerInteractWithUi)
		{
			gameObject.SetActive(true);
			UpdateUI(data);
			m_currentMaterialDeposit = deposit;
		}
	}

	public void UpdateUI(MaterialDepositUIModel model)
	{
		m_type.text = Mappings.MapMaterialTypeToString(model.Type);
		m_amount.text = model.Amount.ToString();
		m_description.text = model.Description;
	}

	public void UpdateAmount()
	{
		m_amount.text = m_currentMaterialDeposit.DepositAmount.ToString();
	}
}
