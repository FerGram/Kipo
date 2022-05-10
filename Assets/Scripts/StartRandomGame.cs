using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartRandomGame : MonoBehaviour
{
    [SerializeField] Transform _newDoorPos;
	[SerializeField] float freezeTime = 3f;

    public static bool _alreadyTriggered = false;
    private GameObject _firstDoor;
	private GameObject _lastDoor;


    private void Awake()
    {
		_firstDoor = GameObject.Find("FirstDoor");
		_lastDoor = GameObject.Find("LastDoor");

		
		if (_alreadyTriggered) 
        {
            GetComponent<BoxCollider2D>().enabled = false;
            SetPlayerMovementActive(true);
            ChangeDoor(); 
        }
		else
		{
			if (_lastDoor != null) _lastDoor.SetActive(false);
		}
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            _alreadyTriggered = true;
            GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(PauseGame());
        }
    }

    IEnumerator PauseGame()
    {
        SetPlayerMovementActive(false);
        ChangeDoor();
        yield return new WaitForSeconds(freezeTime);
        SetPlayerMovementActive(true);
    }

    void SetPlayerMovementActive(bool isEnabled)
    {
        PlayerMovement _player = GameObject.Find("Player").GetComponent<PlayerMovement>();

        //_player.gameObject.GetComponentInChildren<Animator>().SetBool("isMoving", isEnabled);
        _player.gameObject.GetComponent<RandomPlayerMovement>().enabled = isEnabled;
        _player._canMove = isEnabled;
    }
    void ChangeDoor()
    {
		_firstDoor.SetActive(false);

		if (_lastDoor != null) _lastDoor.SetActive(true);
    }
}
