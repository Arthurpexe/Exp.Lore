using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PersonagemStats))]
public class Boss1Combate : MonoBehaviour
{
	public float velocidadeAtaque = 1f;
	private float cooldownAtaque = 0f;
	public float CooldownAtaque;
	public float ataqueDelay = .6f;
	private Rigidbody player;
	RaycastHit alvo;
	public float delayAnimaçaoDeAviso = 0f;
	float delayAnimaçaoAtual = 0f;
	Renderer rend;
	GameObject jogador;



	PersonagemStats myStats;

	void Start()
	{
		player = GetComponent<Rigidbody>();
		myStats = GetComponent<PersonagemStats>();
		jogador = GameObject.FindGameObjectWithTag("Player");
		rend = jogador.GetComponentInChildren<Renderer>();

	}


	void Update()
	{
		cooldownAtaque -= Time.deltaTime;
		delayAnimaçaoAtual = delayAnimaçaoDeAviso;
		
	}




	



	public void Ataque(PersonagemStats alvoStats)
	{
		
		if (cooldownAtaque <= 0)
		{
			Debug.Log("Vou atacar!");
			// chamar a animação de aviso que vai atacar do boss


			Physics.Raycast(transform.position + Vector3.down * 2, transform.forward * 10, out alvo);
				//Executar animação de ataque.

				if (alvo.transform.name == "Personagem")
				{
					DarDano(alvoStats);
					cooldownAtaque = CooldownAtaque;
				    rend.material.color = Color.red;

				}
				else
				{
					cooldownAtaque = CooldownAtaque;
				}
			
			
			

		}
	}
			

			


		
			


	public void DarDano(PersonagemStats stats) 
	{
		
		stats.TomarDano(myStats.dano.PegarValor());
		rend.material.color = Color.red;
	}

			
}



	

	


	





