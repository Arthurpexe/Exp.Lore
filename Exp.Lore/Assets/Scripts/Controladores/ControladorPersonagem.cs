using UnityEngine;
using System.Xml.Serialization;
using System.IO;

public class ControladorPersonagem : MonoBehaviour
{
	#region Singleton
	public static ControladorPersonagem instancia;

	private void Awake()
	{
		if (instancia != null)
		{
			Debug.LogWarning("Mais de uma instancia de ControladorPersonagem encontrada!");
			return;
		}
		instancia = this;

	}
	#endregion

	static Animator anim;
	public float SpeedIncrease = 10f;
	public float Speed = 5f;

	public float GroundDistance = 0.2f;
	public float DashDistance = 2f;
	public LayerMask Ground;
	public int PlayerNumber = 1;

	public GameObject menu;
	private Rigidbody player;
	private Vector3 _inputs = Vector3.zero;
	private bool _isGrounded = true;
	public bool _isFastSpeed = false;
	private bool Abaixar = false;
	private Transform _groundChecker;
	Camera cam;
	public Interagivel focus;
	
	public Player personagem;
	public GameObject[] Inimigo;
	public float distancia;
	public float distanciaMaxina = 5.0f;


	

	void Start()
	{


		cam = Camera.main;
		player = GetComponent<Rigidbody>();
		_groundChecker = transform.GetChild(0);
		anim = GetComponent<Animator>();

		personagem = new Player();
	}

	void Update()
	{
		if (menu.activeSelf)
		{
			_inputs = Vector3.zero;
			return;
		}


		_isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);



		_inputs = Vector3.zero;
		_inputs.x = Input.GetAxis("Horizontal");
		_inputs.z = Input.GetAxis("Vertical");



		if (_inputs != Vector3.zero)
		{
			anim.SetFloat("mov", 1);

			transform.forward = -_inputs;
		}

		if (Input.GetButton("Correr_p1"))
		{
			if (_isFastSpeed == false)
			{
				_isFastSpeed = true;

			}
		}

		if (_inputs.magnitude < 0.05f)
		{
			_isFastSpeed = false;
			anim.SetFloat("mov", 0);
		}

		if (_isFastSpeed == true)
		{
			anim.SetFloat("mov", 2);
			anim.SetBool("agachado", false);
			_inputs = _inputs * SpeedIncrease;
		}

		if (Input.GetButtonDown("Abaixar"))
		{
			if (Abaixar == false)
			{
				Abaixar = true;
				anim.SetBool("agachado", true);
				Debug.Log("Agachado");
			}

			else
			{
				Abaixar = false;
				anim.SetBool("agachado", false);
				Debug.Log("De pé");
			}
		}



		if (Abaixar == true && Input.GetButtonDown("Dash_p1"))
		{
			anim.SetTrigger("rolar");
			Vector3 dashVelocity = Vector3.Scale(transform.forward, DashDistance * new Vector3(5, 0, 5));
			player.AddForce(dashVelocity, ForceMode.VelocityChange);
		}

		if (Input.GetButtonDown("Atacar") && _isFastSpeed == false)
		{

			anim.SetTrigger("atacar");
		}

		
	}

		
		

		
		






		


	void FixedUpdate()
	{
		player.MovePosition(player.position - _inputs * Speed * Time.fixedDeltaTime);
	}



	/// <summary>
	/// Parte de Salvar e Carregar!!!
	/// </summary>
	public void salvarPosicao()
	{
		this.personagem.posicao = this.transform.position;
		SaveLoad.instancia.salvarPlayer(personagem);
		Debug.Log("Salvei o Jogo");
	}
	public void carregarPosicao()
	{

		Player aux = SaveLoad.instancia.carregarPlayer();
		this.personagem.posicao = aux.posicao;
		transform.position = this.personagem.posicao;
		Debug.Log("Carreguei o Jogo");
	}
	public void Add(System.Object ot)
	{
		throw new FileNotFoundException();
	}
}







