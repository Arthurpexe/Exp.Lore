using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoStats : PersonagemStats
{
	public float radius = 3f;
	public Transform interactionTransform;
	
	public GameObject player;
	PersonagemCombate cooldown;
	public float CoolDown;
	Animator anim;
    


    private void Start()
	{
		player = GameObject.FindWithTag("Player");
		cooldown = player.GetComponent<PersonagemCombate>();
		float Cooldown = cooldown.CooldownAtaque;
		CoolDown = Cooldown;
		anim = GetComponentInChildren<Animator>();

	}



	void Update()
	{
		float Cooldown = cooldown.CooldownAtaque;
		float distance = Vector3.Distance(player.transform.position, interactionTransform.position);

		if (Input.GetButtonDown("Atacar") && (distance <= radius) && (Cooldown <= 0))
		{
			TomarDano(danoInimigo);

		}
	}


	public override void MorrerAnimaçao()
	{
		

		anim.SetTrigger("Morrer");
		//Destroy(gameObject);
	}

	public override void Morrer()
	{
		Destroy(gameObject);
	}

}
