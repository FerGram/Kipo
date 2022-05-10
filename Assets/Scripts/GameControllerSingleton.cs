using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerSingleton : MonoBehaviour
{
	private static GameControllerSingleton Instance;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else { Destroy(gameObject); }
	}
}
