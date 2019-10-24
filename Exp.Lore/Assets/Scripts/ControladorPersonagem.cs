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
	private bool _isFastSpeed = false;
	private bool Abaixar = false;
	private Transform _groundChecker;
    Camera cam;
    public Interagivel focus;

    public Player personagem;
    void Start()
	{
        cam = Camera.main;
		player = GetComponent<Rigidbody>();
		_groundChecker = transform.GetChild(0);


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
