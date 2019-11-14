
using UnityEngine;
using UnityEngine.AI;

public class PersonagemStats : MonoBehaviour
{
	Renderer rend;
	public int vidaMaxima = 100;
    public int vidaAtual; //{ get; private set; }
	public int danoInimigo;
	public int dano;
	public int armadura;
	

	public GameObject item;
	public GameObject player;

    public event System.Action<int, int> seVidaMudar;

	private void Awake()
	{

		rend = GetComponentInChildren<Renderer>();
		vidaAtual = vidaMaxima;
        player = GameObject.FindWithTag("Player");


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
            if (item != null)
            {
                Instantiate(item, this.transform.position, Quaternion.identity);
                item.GetComponent<Interagivel>().player = player;
            }
			MorrerAnimaçao();
		}

		
	}

    public void carregarVida()
    {
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
