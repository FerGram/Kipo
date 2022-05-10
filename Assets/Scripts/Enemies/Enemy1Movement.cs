using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Movement : MonoBehaviour
{
	[SerializeField] float _xSpeed = 3;

	[HideInInspector] public bool _isMovingRight;
	bool _canMove = true;
	Rigidbody2D _rigidbody;
	PlayerMovement _player;

	private void Start()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		_player = FindObjectOfType<PlayerMovement>().GetComponent<PlayerMovement>();
	}

	// Update is called once per frame
	void Update()
    {
        if (_canMove)
		{
			if (_isMovingRight) Move(1);
			else Move(-1);
		}

		if (WorldRotation._isRotating) transform.up = Vector3.Slerp(transform.up, Vector3.up, 8);

	}
	private void FixedUpdate()
	{
		ApplyGravity();
	}

	private void ApplyGravity()
	{
		//Personalized gravity to be able to adapt it to the World Rotate mechanic.
		//_rigidbody.AddForce(_player.gravity * Vector2.up);
	}

	void Move(int dir)
	{
		Vector3 movementVector = new Vector3(dir, 0f);
		transform.position += movementVector * _xSpeed * Time.deltaTime;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawLine(transform.position, transform.position + Vector3.down);

		Gizmos.color = Color.red;
		Gizmos.DrawLine(transform.position, transform.position - transform.up);
	}
}
