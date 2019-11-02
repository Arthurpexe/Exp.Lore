using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Cuida das interações com o inimigo
[RequireComponent(typeof(PersonagemStats))]
public class Inimigo : Interagivel
{
	Ref_posiçao_jogador playerManager;
	PersonagemStats myStats;

	private void Start()
	{
		playerManager = Ref_posiçao_jogador.instance;
		myStats = GetComponent<PersonagemStats>();
	}

	public override void Interact()
	{
		base.Interact();
		PersonagemCombate playerCombat = playerManager.player.GetComponent<PersonagemCombate>();
        if(playerCombat != null)
		{
			playerCombat.Ataque(myStats);
		}

	}

}
