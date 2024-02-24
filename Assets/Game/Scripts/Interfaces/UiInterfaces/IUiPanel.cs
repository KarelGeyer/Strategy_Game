using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUiPanel<T>
{
	void CloseUI();

	void UpdateUI(T model);
}
