using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1CheckDirX : MonoBehaviour
{
	Enemy1Movement _enemyMovementS;
	
	private void Awake()
	{
		_enemyMovementS = transform.parent.gameObject.GetComponent<Enemy1Movement>();

	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Floor" || col.gameObject.layer == 8)
		{
			_enemyMovementS._isMovingRight = !_enemyMovementS._isMovingRight;
			_enemyMovementS.gameObject.transform.localScale = new Vector3(-_enemyMovementS.gameObject.transform.localScale.x, 1, 1);
		}
	}
}
