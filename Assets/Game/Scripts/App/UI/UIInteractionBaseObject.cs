using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInteractionBaseObject : MonoBehaviour
{
	private void OnEnable()
	{
		if (UI_Manager.Instance)
		{
			UI_Manager.Instance.CanPlayerInteractWithUi = false;
		}
	}

	private void OnDisable()
	{
		UI_Manager.Instance.CanPlayerInteractWithUi = true;
	}

	public virtual void CloseUI()
	{
		gameObject.SetActive(false);
	}
}
