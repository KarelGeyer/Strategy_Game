using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInteractionBaseObject : MonoBehaviour
{
	private void OnEnable()
	{
		UI_Manager.Instance.CanPlayerInteractWithUi = false;
	}

	private void OnDisable()
	{
		UI_Manager.Instance.CanPlayerInteractWithUi = true;
	}
}