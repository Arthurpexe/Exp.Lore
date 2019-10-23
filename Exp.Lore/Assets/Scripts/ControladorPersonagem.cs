using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControladorPersonagem : MonoBehaviour
{
	public float SpeedIncrease = 5f;
	public float Speed = 5f;

	public float GroundDistance = 0.2f;
	public float DashDistance = 2f;
	public LayerMask Ground;
	public int PlayerNumber = 1;

	private Rigidbody player;
	private Vector3 _inputs = Vector3.zero;
	private bool _isGrounded = true;
	private bool _isFastSpeed = false;
	private bool Abaixar = false;
	private Transform _groundChecker;
	Camera cam;
	public Interagivel focus;



	// Start is called before the first frame update
	void Start()
	{
		cam = Camera.main;
		player = GetComponent<Rigidbody>();
		_groundChecker = transform.GetChild(0);





	}

	// Update is called once per frame
	void Update()
	{
		

		_isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);



		_inputs = Vector3.zero;
		_inputs.x = Input.GetAxis("Horizontal");
		_inputs.z = Input.GetAxis("Vertical");
		if (_inputs != Vector3.zero)
		{
			transform.forward = _inputs;

			
		}
			

		if (Input.GetButtonDown("Correr_p1")) 
		{
			if (_isFastSpeed == false)
			{
				_isFastSpeed = true;
			}
		}

		if (_inputs.magnitude < 0.05f)
		{
			_isFastSpeed = false;
		}

		if (_isFastSpeed == true)
		{
			_inputs = _inputs * SpeedIncrease;
		}

		if (Input.GetButtonDown("Abaixar"))
		{
			if(Abaixar == false)
			{
				Abaixar = true;
			}
		} else
		{
			Abaixar = false;
		}


		if (Input.GetButtonDown("Dash_p1"))
		{
			//Vector3 dashVelocity = Vector3.Scale(transform.forward, DashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * _body.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * _body.drag + 1)) / -Time.deltaTime)));
			Vector3 dashVelocity = Vector3.Scale(transform.forward, DashDistance * new Vector3(5,0,5));
			player.AddForce(dashVelocity, ForceMode.VelocityChange);
		}

		

	}

	void FixedUpdate()
	{
		player.MovePosition(player.position + _inputs * Speed * Time.fixedDeltaTime);
	}

	

			

		
		
		
	

	
}
