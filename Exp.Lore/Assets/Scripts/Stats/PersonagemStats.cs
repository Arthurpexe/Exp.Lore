
using UnityEngine;
using UnityEngine.AI;

public class PersonagemStats : MonoBehaviour
{
	Renderer rend;
	NavMeshAgent personagem;
	public int vidaMaxima = 100;
    public int vidaAtual; //{ get; private set; }
	public int danoInimigo;
	public int dano;
	public int armadura;

    public event System.Action<int, int> seVidaMudar;

	private void Awake()
	{
		rend = GetComponentInChildren<Renderer>();
		vidaAtual = vidaMaxima;
		personagem = GetComponent<NavMeshAgent>();
	}


	void Update() 
	{
		rend.material.color = Color.white;

		if (Input.GetButtonDown("Interagir"))
		{
			TomarDano(danoInimigo);
			
		}
		
	}


	public void TomarDano(int dano)
	{
		dano -= armadura;
		dano = Mathf.Clamp(dano, 0, int.MaxValue);

		vidaAtual -= dano;
		rend.material.color = Color.red;

		Debug.Log(transform.name + " Tomou " + dano + " dano.");

        if (seVidaMudar != null)
        {
            seVidaMudar(vidaMaxima, vidaAtual);
        }

		if(vidaAtual <= 0)
		{
			MorrerAnimaçao();
		}

		
	}

    public void carregarVida()
    {
        Debug.Log("vida atual" + vidaAtual);
        seVidaMudar(vidaMaxima, vidaAtual);
        Debug.Log("vida atual"+vidaAtual);
    }


	public virtual void MorrerAnimaçao()
	{


		
	}

	public virtual void Morrer()
	{

	}
}
