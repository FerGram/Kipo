using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

	private static PlayerMovement _playerMovementS;

	private string _DeviceType;
	private bool _isHandheld;

	public static bool _isFirstTryOnThisLevel = true;
	static int _sceneIndex = -1;

	private static PlayableDirector _director;

	private static RandomPlayerMovement _randomPlayerMovementS;
	private static bool _originalStateOfRandomScript;

	// Start is called before the first frame update
	void Awake()
    {
		if (SystemInfo.deviceType == DeviceType.Handheld)
		{
			_DeviceType = "Handheld";
			_isHandheld = true;
		}
		else
		{
			_DeviceType = "Desktop";
			_isHandheld = false;
			var joystickCanvas = GameObject.Find("JoystickCanvas");
			if (joystickCanvas != null) { joystickCanvas.SetActive(false); }
		}

		if (GameObject.Find("Player") != null)
        {
			_playerMovementS = GameObject.Find("Player").GetComponent<PlayerMovement>();
		}
		if (GameObject.Find("Timeline") != null)
        {
			_director = GameObject.Find("Timeline").GetComponent<PlayableDirector>();
		}
	}

    // Update is called once per frame
    void Update()
    {
		if (_director != null && _director.state == PlayState.Paused && _isFirstTryOnThisLevel)
		{
			GameObject.Find("World").GetComponent<LocateAllEnemies>().EnemiesActive(true);
			_playerMovementS.GetComponent<PlayerMovement>()._canMove = true;
			_isFirstTryOnThisLevel = false;
			_randomPlayerMovementS.enabled = _originalStateOfRandomScript;
		}
	}

	private void OnEnable()
	{
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}

	private void OnDisable()
	{
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;
	}

	private void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
	{
		_randomPlayerMovementS = GameObject.Find("Player")?.GetComponent<RandomPlayerMovement>();
		if (_randomPlayerMovementS != null) _originalStateOfRandomScript = _randomPlayerMovementS.enabled;
		

		if (_sceneIndex == SceneManager.GetActiveScene().buildIndex) //If second or more times.
		{
			_isFirstTryOnThisLevel = false;
			_director.gameObject.SetActive(false); //Deactivate Timeline.
			_playerMovementS._canMove = true;
			_randomPlayerMovementS.enabled = true;

		}
		else
		{
			_isFirstTryOnThisLevel = true;

			if (_randomPlayerMovementS != null)
            {
				_playerMovementS._canMove = false;
				_randomPlayerMovementS.enabled = false;
			}
			
			_sceneIndex = SceneManager.GetActiveScene().buildIndex;
		}
	}

	public void WinLevel(int nextLevel)
    {
		PlayerPrefs.SetInt("levelReached", nextLevel);
    }
}
