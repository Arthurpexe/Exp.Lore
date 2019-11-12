
using UnityEngine;

[CreateAssetMenu(fileName = "Novo Item", menuName = "Inventário/Item")]
public class Item : ScriptableObject
{
	public string tag;
    public string nome = "Novo Item";
	public int vida;
	public int dano;
	public int armadura;
    public Sprite icon = null;
    public bool isDefaultItem = false;
	GameObject player;
	JogadorStats stats;


	public void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		stats = player.GetComponent<JogadorStats>();

	}


	public virtual void Use()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		stats = player.GetComponent<JogadorStats>();
		
		if(tag == "Consumivel")
		{
			if(stats.vidaAtual + vida <= 100)
			{

				stats.vidaAtual = stats.vidaAtual + vida;

			}

			if (!(stats.vidaAtual + vida <= 100))
			{
				stats.vidaAtual = 100;
			}

			if( stats.dano + dano <= 100)
			{
				stats.dano = stats.dano + dano;
			}

			if (!(stats.dano + dano <= 100))
			{
				stats.dano = 100;
			}

			if (stats.armadura + armadura <= 100)
			{
				stats.armadura = stats.armadura + armadura;
			}

			if (!(stats.armadura + armadura <= 100))
			{
				stats.armadura = 100;
			}
		}
			
		
	}

    public virtual void desequipar()
    {
        //dessequipar o item
    }


    public void RemoverDoInventario()
	{
		Inventario.instance.Remove(this);
        Debug.Log("removi " + this.nome);
	}

}
