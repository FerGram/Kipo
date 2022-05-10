using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2CheckDirX : MonoBehaviour
{
	Enemy2Movement _enemy2MovementS;

	private void Awake()
	{
		_enemy2MovementS = transform.parent.gameObject.GetComponent<Enemy2Movement>();
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		
		if ((col.gameObject.tag == "Floor" || col.gameObject.layer == 8) && this.gameObject.name == "xDirCheck")
		{
			_enemy2MovementS._isMovingRight = !_enemy2MovementS._isMovingRight;
			_enemy2MovementS.gameObject.transform.localScale = new Vector3(-_enemy2MovementS.gameObject.transform.localScale.x, 1, 1);
		}
	}
}
