
using UnityEngine;
using UnityEngine.AI;

public class PersonagemStats : MonoBehaviour
{

	NavMeshAgent personagem;
	public int vidaMaxima = 100;
    public int vidaAtual; //{ get; private set; }
	public int danoInimigo;
	public Stats dano;
	public Stats armadura;

    public event System.Action<int, int> seVidaMudar;

	private void Awake()
	{
		vidaAtual = vidaMaxima;
		personagem = GetComponent<NavMeshAgent>();
	}


	void Update() 
	{
		if (Input.GetButtonDown("Interagir"))
		{
			TomarDano(danoInimigo);
			
		}
		
	}


	public void TomarDano(int dano)
	{
		dano -= armadura.PegarValor();
		dano = Mathf.Clamp(dano, 0, int.MaxValue);

		vidaAtual -= dano;
		
		Debug.Log(transform.name + " Tomou " + dano + " dano.");

        if (seVidaMudar != null)
        {
            seVidaMudar(vidaMaxima, vidaAtual);
        }

		if(vidaAtual <= 0)
		{
			Die();
		}

		
	}

    public void carregarVida()
    {
        seVidaMudar(vidaMaxima, vidaAtual);
    }


	public virtual void Die()
	{


		
	}
}
