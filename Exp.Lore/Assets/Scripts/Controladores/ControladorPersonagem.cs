using UnityEngine;

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

	[Header("Graficos")]
	Renderer rend;

	[Header("Paineis")]
    public GameObject painelMenu;
    public GameObject painelInventario;
    public GameObject painelFimDeJogo;

    [Header("Movimento")]
    public float SpeedIncrease = 10f;
    public float Speed = 5f;
    public float DashDistance = 2f;
    public int PlayerNumber = 1;
    public Rigidbody player;
    public Vector3 _inputs = Vector3.zero;
    public bool _isFastSpeed = false;
    private bool Abaixar = false;
    static Animator anim;

    [Header("Combate")]
	PersonagemCombate cooldown;
    public PersonagemStats personagemStats;
    public int vidaAtual;
    public GameObject barraVidaBoss;
    public GameObject[] inimigos;
    public float distancia;
    public float distaciaMaxima = 5.0f;

    [Header("Save")]
    public Player personagem;

    [Header("Missoes")]
    public Missao[] missoesAtivas;
    public int contadorMissoesAtivas = 0;
    public int ouro;
    public GameObject titulo;


    public delegate void SeMissaoMudar();
    public SeMissaoMudar seMissaoMudarCallback;


    void Start()
	{
		rend = GetComponentInChildren<Renderer>();
		missoesAtivas = new Missao[6];
		player = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
		cooldown = GetComponent<PersonagemCombate>();
        personagem = new Player();

        personagemStats = this.GetComponent<PersonagemStats>();
    }

	void Update()
	{
		rend.material.color = Color.white;
		vidaAtual = personagemStats.vidaAtual;

        if (painelMenu.activeSelf || painelInventario.activeSelf || painelFimDeJogo.activeSelf)
        {
            _inputs = Vector3.zero;
            return;
        }

        

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
		
			
        


		if (Abaixar == true && Input.GetButtonDown("Correr_p1"))
		{
			anim.SetTrigger("rolar");
			_isFastSpeed = false;
			anim.SetBool("agachado", true);
			Vector3 dashVelocity = Vector3.Scale(transform.forward, DashDistance * new Vector3(5,0,5));
			player.AddForce(dashVelocity, ForceMode.VelocityChange);
			
		}

        if (Input.GetButtonDown("Atacar") && !_isFastSpeed && cooldown.cooldownAtaque <= 0)
        {
            anim.SetTrigger("atacar");
        }
    }

	void FixedUpdate()
	{
		player.MovePosition(player.position - _inputs * Speed * Time.fixedDeltaTime);
	}

    public void mudouMissao()
    {
        Debug.Log("missao do player é " + missoesAtivas[contadorMissoesAtivas-1].titulo);
        seMissaoMudarCallback.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "AreaBoss")
        {
            barraVidaBoss.SetActive(true);
        }
        if (other.tag == "AreaBaseCachoeira")//verifico se cheguei na cachoeira para completar a missao Onde estão meus pais
        {
            for (int i = 0; i < missoesAtivas.Length; i++)
            {
                if (missoesAtivas[i].titulo == "Onde estão meus pais")
                {
                    if (missoesAtivas[i].objetivo.tipoObjetivo == TipoObjetivo.irAte)
                    {
                        missoesAtivas[i].objetivo.chegouNumLugar();
                        if (missoesAtivas[i].objetivo.concluiu())
                        {
                            ouro += missoesAtivas[i].recompensaOuro;
                            missoesAtivas[i].missaoConcluida();
                            //feedback de missao concluida
                            seMissaoMudarCallback.Invoke();
                        }
                    }
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "AreaBoss")
        {
            barraVidaBoss.SetActive(false);
        }
        if(other.tag == "AreaTitulo")
        {
            titulo.SetActive(false);
        }
    }
}
