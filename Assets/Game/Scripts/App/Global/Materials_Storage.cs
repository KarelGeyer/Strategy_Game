using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materials : MonoBehaviour
{
	private int m_amountOfRock = 0;

	public int AmountOfRock
	{
		get { return m_amountOfRock; }
		set { m_amountOfRock = value; }
	}
}
