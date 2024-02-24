using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Base_Object : MonoBehaviour
{
	private void OnEnable()
	{
		GameManager.Instance.SetCanInteract(false);
	}

	private void OnDisable()
	{
		GameManager.Instance.SetCanInteract(true);
	}
}
