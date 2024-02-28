using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class MaterialStorageUi : MonoBehaviour, IUiPanel<MaterialStorageUIModel>
{
	[SerializeField]
	private TextMeshProUGUI m_woodAmount;

	[SerializeField]
	private TextMeshProUGUI m_silverAmount;

	[SerializeField]
	private TextMeshProUGUI m_rockAmount;

	[SerializeField]
	private TextMeshProUGUI m_gemsAmount;

	[SerializeField]
	private TextMeshProUGUI m_foodAmount;

	public void CloseUI() { }

	/// <summary>
	/// Updates respective text mesh based on <see cref="MaterialType"/> provided.
	/// </summary>
	/// <param name="model"></param>
	public void UpdateUI(MaterialStorageUIModel model)
	{
		switch (model.MaterialType)
		{
			case MaterialType.Rock:
				m_rockAmount.text = model.Value.ToString();
				break;
			case MaterialType.Wood:
				m_woodAmount.text = model.Value.ToString();
				break;
			case MaterialType.Silver:
				m_silverAmount.text = model.Value.ToString();
				break;
			case MaterialType.Food:
				m_foodAmount.text = model.Value.ToString();
				break;
			case MaterialType.Gems:
				m_gemsAmount.text = model.Value.ToString();
				break;
		}
	}
}
