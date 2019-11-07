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

    public GameObject painelMenu, painelInventario, painelFimDeJogo;

	public Rigidbody player;

	public Vector3 _inputs = Vector3.zero;

    public bool _isFastSpeed = false;
    private bool _isGrounded = true;
	private bool Abaixar = false;
	private Transform _groundChecker;
    private Camera cam;

    public PersonagemStats personagemStats;

    public Interagivel focus;
    public GameObject barraVidaBoss;
    public GameObject[] inimigos;
    public float distancia;
    public float distaciaMaxima = 5.0f;

    public int vidaAtual;

    public Player personagem;
    void Start()
	{
        cam = Camera.main;
		player = GetComponent<Rigidbody>();
		_groundChecker = transform.GetChild(0);
        anim = GetComponentInChildren<Animator>();

        personagem = new Player();

        personagemStats = this.GetComponent<PersonagemStats>();
    }

	void Update()
	{
        vidaAtual = personagemStats.vidaAtual;

        if (painelMenu.activeSelf || painelInventario.activeSelf || painelFimDeJogo.activeSelf)
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

        if (Input.GetButtonDown("Correr_p1")) 
		{
			if (_isFastSpeed == false)
			{
				_isFastSpeed = true;
			}
		}

		if (_inputs.magnitude < 0.05f)
		{
			anim.SetFloat("mov", 0);
			_isFastSpeed = false;
		}

		if (_isFastSpeed == true)
		{
            anim.SetFloat("mov", 2);
            anim.SetBool("agachado", false);
			_inputs = _inputs * SpeedIncrease;
		}

		if (Input.GetButtonDown("Abaixar"))
		{
			if(Abaixar == false)
			{
				Abaixar = true;
                anim.SetBool("agachado", true);


			}


			else
			{
				Abaixar = false;
				anim.SetBool("agachado", false);
			}
		} 
		
			
        


		if (Abaixar == true && Input.GetButtonDown("Dash_p1"))
		{
            anim.SetTrigger("rolar");
			Vector3 dashVelocity = Vector3.Scale(transform.forward, DashDistance * new Vector3(5,0,5));
			player.AddForce(dashVelocity, ForceMode.VelocityChange);
			anim.SetFloat("mov", 0);
			anim.SetBool("agachado", true);
		}

        if (Input.GetButtonDown("Atacar") && !_isFastSpeed)
        {
            anim.SetTrigger("atacar");
        }
    }

	void FixedUpdate()
	{
		player.MovePosition(player.position - _inputs * Speed * Time.fixedDeltaTime);
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "AreaBoss")
        {
            barraVidaBoss.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "AreaBoss")
        {
            barraVidaBoss.SetActive(false);
        }
    }
}
