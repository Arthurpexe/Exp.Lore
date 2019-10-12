using UnityEngine;
using System.Xml.Serialization;
using System.IO;

public class ControladorPersonagem : MonoBehaviour
{
	public float SpeedIncrease = 10f;
	public float Speed = 5f;

	public float GroundDistance = 0.2f;
	public float DashDistance = 2f;
	public LayerMask Ground;
	public int PlayerNumber = 1;

	private Rigidbody _body;
	private Vector3 _inputs = Vector3.zero;
	private bool _isGrounded = true;
	private bool _isFastSpeed = false;
	private bool Abaixar = false;
	private Transform _groundChecker;


    public Player personagem;//parte do save/load
    public Criptografia cripto;//parte de criptografia

    void Start()
	{
		_body = GetComponent<Rigidbody>();
		_groundChecker = transform.GetChild(0);



        personagem = new Player();//parte do save/load
        cripto = new Criptografia();//parte de criptografia
    }

	void Update()
	{
		_isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);



		_inputs = Vector3.zero;
		_inputs.x = Input.GetAxis("Horizontal");
		_inputs.z = Input.GetAxis("Vertical");
		if (_inputs != Vector3.zero)
			transform.forward = _inputs;

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
			_body.AddForce(dashVelocity, ForceMode.VelocityChange);
		}


	}

	void FixedUpdate()
	{
		_body.MovePosition(_body.position + _inputs * Speed * Time.fixedDeltaTime);
	}



    /// <summary>
    /// Parte de Salvar e Carregar!!!
    /// </summary>
    public void salvarPosicao()
    {
        this.personagem.posicao = transform.position;
        XmlSerializer serializador = new XmlSerializer(typeof(Player));
        StreamWriter arqDados = new StreamWriter("PlayerPosicao.xml");
        serializador.Serialize(arqDados.BaseStream, personagem);
        arqDados.Close();

        cripto.criptografarArquivo("PlayerPosicao.xml", '§');
    }
    public void carregarPosicao()
    {
        cripto.descriptografarArquivo("PlayerPosicao.xml", '§');

        XmlSerializer serializador = new XmlSerializer(typeof(Player));
        StreamReader arqLeit = new StreamReader("PlayerPosicao.xml");
        Player aux = (Player)serializador.Deserialize(arqLeit.BaseStream);
        arqLeit.Close();
        this.personagem.posicao = aux.posicao;
        transform.position = this.personagem.posicao;
    }
    public void Add(System.Object ot)
    {
        throw new FileNotFoundException();
    }
    public void quit()
    {
        Application.Quit();
    }





}
