using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public static GameManager Instance
	{
		get { return instance; }
	}

	private void Awake()
	{
		ManageInstance();
	}

	private void ManageInstance()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void PauseGame()
	{
		Time.timeScale = 0f;
	}

	public void ResumeGame()
	{
		Time.timeScale = 1f;
	}
}
