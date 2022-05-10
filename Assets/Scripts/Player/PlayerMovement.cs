
using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] float _xSpeed = 5;
	[SerializeField] float _jumpForce = 500;
	[SerializeField] ParticleSystem _runParticles;

	[Header("Ground Check")]
	[SerializeField] LayerMask _whatIsGround;
	[SerializeField] Transform _groundCheck;
	[SerializeField] float _checkRadius = 0.5f;

	public float gravity { get; private set; } = -27f;

	private Rigidbody2D _rigidbody;
	private Animator _animator;
	private AudioManager _audioManager;

	private bool _isGrounded = false;
	private float _xMovement;

	[HideInInspector] public bool _canMove;
    public void SetGravity(float value)
    {
        gravity = value;
    }

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponentInChildren<Animator>();
        _audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
		if (_canMove)
		{
			if (SimpleInput.GetAxisRaw("Horizontal") != 0)
			{
					_xMovement = SimpleInput.GetAxisRaw("Horizontal") < 0 ? -1f : 1f;
			}
			else
			{
				_xMovement = 0f;
			}
			
			

			StartRunParticles();

			//Jump input.
			if (SimpleInput.GetButtonDown("Space") && _isGrounded) Jump(1f);
		}
		else
		{
			_xMovement = 0f;
		}

    }
    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _whatIsGround);
        MovePlayer();
        SetBoolAndChangeScale();
        ApplyGravity();
    }

    private void StartRunParticles()
    {
        if ((_rigidbody.velocity.x > 2 || _rigidbody.velocity.x < -2) && _isGrounded && !_runParticles.isPlaying)
        {
            _runParticles.Play();
        }
        else if (!_isGrounded || (_rigidbody.velocity.x < 2 && _rigidbody.velocity.x > -2))
        {
            _runParticles.Stop();
        }
    }

    private void MovePlayer()
    {
        _rigidbody.velocity = new Vector2(_xMovement * _xSpeed, _rigidbody.velocity.y);
    }
    private void SetBoolAndChangeScale()
    {
        if (_xMovement != 0)
        {
            transform.localScale = new Vector3(_xMovement, 1, 1);
            _animator.SetBool("isMoving", true);
        }
        else { _animator.SetBool("isMoving", false); }
    }

    public void Jump(float jumpMultiplier = 1f)
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
        _rigidbody.AddForce(Vector2.up * _jumpForce * jumpMultiplier * -Mathf.Sign(gravity), ForceMode2D.Impulse);
        _audioManager.PlayerJump();
    }

	private void ApplyGravity()
	{
        //Personalized gravity to be able to adapt it to the World Rotate mechanic.
        _rigidbody.AddForce(gravity * Vector2.up);
	}
}
