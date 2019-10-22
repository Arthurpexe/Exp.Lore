using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float SpeedIncrease = 10f;
	public float Speed = 5f;
	public float JumpHeight = 2f;
	public float GroundDistance = 0.2f;
	public LayerMask Ground;
	public int PlayerNumber = 1;
	private Rigidbody _body;
	private Vector3 _inputs = Vector3.zero;
	private bool _isGrounded = true;
	private Transform _groundChecker;
	private int _doubleJump = 0;
	

	
	


	// Start is called before the first frame update
	void Start()
	{
		_body = GetComponent<Rigidbody>();
		_groundChecker = transform.GetChild(0);

		

	}

	// Update is called once per frame
	void Update()
	{
		_isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);

		if (_isGrounded)
		{
			_doubleJump = 0;
		}

		_inputs = Vector3.zero;
		_inputs.x = Input.GetAxis("Horizontal_p1");
		
		if (_inputs != Vector3.zero)
			transform.forward = _inputs;

		
		if(Input.GetButtonDown("Jump_p1") && (_isGrounded))
		{
			_doubleJump++;
			_body.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);

		}


		if (Input.GetButtonDown("DoubleJump_p1") && (_isGrounded == false) && (_doubleJump < 1))
		{
			_doubleJump++;
			_body.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
		}







	}

	void FixedUpdate()
	{
		_body.MovePosition(_body.position + _inputs * Speed * Time.fixedDeltaTime);
	}
}
		

			
