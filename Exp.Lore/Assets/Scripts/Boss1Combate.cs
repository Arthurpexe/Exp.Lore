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
	public float delayAnimaçaoDeAviso = 2f;



	PersonagemStats myStats;

	void Start()
	{
		player = GetComponent<Rigidbody>();
		myStats = GetComponent<PersonagemStats>();
	}


	void Update()
	{
		cooldownAtaque -= Time.deltaTime;

	}

	public void Ataque(PersonagemStats alvoStats)
	{


		if (cooldownAtaque <= 0)
		{
			Debug.Log("Vou atacar!");
			// chamar a animação de aviso que vai atacar do boss

			StartCoroutine(CalcularRaycast(delayAnimaçaoDeAviso - 0.1f));       

			StartCoroutine(AnimacaoAtaqueBoss1(delayAnimaçaoDeAviso));

			if (alvo.transform == player.transform)
			{
				DarDano(alvoStats);
				cooldownAtaque = CooldownAtaque;
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

	}


	IEnumerator AnimacaoAtaqueBoss1(float delay)
	{
		yield return new WaitForSeconds(delay);
		// chamar a animação de ataque onde o Raycast atingiu. esta salvo onde o Raycast bateu na variavel "alvo".
		Debug.Log("Ataquei");
		
	}

	IEnumerator CalcularRaycast(float delay)
	{
		yield return new WaitForSeconds(delay);

		Physics.Raycast(transform.position, player.transform.position, out alvo, 25);
		Debug.Log("raycast calculado");
	}

	
}



