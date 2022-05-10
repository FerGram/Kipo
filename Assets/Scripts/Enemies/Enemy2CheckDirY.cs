using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2CheckDirY : MonoBehaviour
{
	Enemy2Movement _enemy2MovementS;

	private void Awake()
	{
		_enemy2MovementS = transform.parent.gameObject.GetComponent<Enemy2Movement>();
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if ((col.gameObject.tag == "Floor" || col.gameObject.layer == 8) && this.gameObject.name == "yDirCheck")
		{
			_enemy2MovementS._isMovingUp = !_enemy2MovementS._isMovingUp;
			transform.localScale = new Vector3(1, -transform.localScale.y, 1);
		}
	}
}
