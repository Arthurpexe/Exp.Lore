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
	ControladorPersonagem estaCorrendo;
	public bool EstaCorrendo;


	private void Start()
	{
		player = GameObject.FindWithTag("Player");
		cooldown = player.GetComponent<PersonagemCombate>();
		float Cooldown = cooldown.CooldownAtaque;
		CoolDown = Cooldown;
		estaCorrendo = player.GetComponent<ControladorPersonagem>();
		EstaCorrendo = estaCorrendo._isFastSpeed;
	}



	void Update()
	{
		float Cooldown = cooldown.CooldownAtaque;
		float distance = Vector3.Distance(player.transform.position, interactionTransform.position);

		if (Input.GetButtonDown("Atacar") && (distance <= radius) && (Cooldown <= 0) && EstaCorrendo == false)
		{
			TomarDano(danoInimigo);

		}
	}


	public override void Die()
	{
		base.Die();

		Destroy(gameObject);
	}

}
