using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PersonagemStats))]
public class PersonagemCombate : MonoBehaviour
{
	public float velocidadeAtaque = 1f;
	private float cooldownAtaque = 0f;
	public float CooldownAtaque;
	public float ataqueDelay = .6f;



	PersonagemStats myStats;

	void Start()
	{
		myStats = GetComponent<PersonagemStats>();
	}


	void Update()
	{
		cooldownAtaque -= Time.deltaTime;
		
	}

	public void Ataque(PersonagemStats alvoStats)
	{
		

		if(cooldownAtaque <= 0)
		{
			

			StartCoroutine(DarDano(alvoStats, ataqueDelay));
			cooldownAtaque = CooldownAtaque;
		}
	}

	IEnumerator DarDano(PersonagemStats stats, float delay) // Atraso para dano acontecer apenas no final da animação de ataque, ao invez de imediatamente.
	{
		yield return new WaitForSeconds(delay);

		stats.TomarDano(myStats.dano.PegarValor());
	}
	
}
