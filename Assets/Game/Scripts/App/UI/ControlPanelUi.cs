using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanelUi : MonoBehaviour
{
	public void OpenConstructionUI()
	{
		UI_Manager.Instance.GetConstructionUI().gameObject.SetActive(true);
		gameObject.SetActive(false);
	}
}
