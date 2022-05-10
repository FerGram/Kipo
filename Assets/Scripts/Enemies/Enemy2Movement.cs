using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Movement : MonoBehaviour
{
	[SerializeField] float _xSpeed = 3;

	[HideInInspector] public bool _isMovingRight;
	[HideInInspector] public bool _isMovingUp;
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
		if (_isMovingRight)
		{
			if (_isMovingUp) Move(1, 1);
			else Move(1, -1);
		}
		else
		{
			if (_isMovingUp) Move(-1, 1);
			else Move(-1, -1);
		}

		if (WorldRotation._isRotating) transform.up = Vector3.Slerp(transform.up, Vector3.up, 8);
	}

    private void FixedUpdate()
    {
		//ApplyGravity();
	}

	private void ApplyGravity()
	{
		//Personalized gravity to be able to adapt it to the World Rotate mechanic.
		_rigidbody.AddForce(_player.gravity * Vector2.up);
	}

	void Move(int dirX, int dirY)
	{
		Vector3 movementVector = new Vector3(dirX, dirY);
		transform.position += movementVector * _xSpeed * Time.deltaTime;
	}

}
