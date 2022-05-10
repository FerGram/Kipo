using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
	private GameObject _player;
	
	public Vector3 _offset;

    // Start is called before the first frame update
    void Start()
    {
		_player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
		transform.position = _player.transform.position + _offset;
    }
}
