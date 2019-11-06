﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorStats : PersonagemStats
{
	static Animator anim;

	// Start is called before the first frame update
	void Start()
    {
		ControladorEquipamento.instance.trocaDeEquipamento += TrocaDeEquipamento;
		anim = GetComponent<Animator>();
	}

    
	void TrocaDeEquipamento (Equipamento novoItem, Equipamento velhoItem)
	{
		if(novoItem != null)
		{
		  armadura.AdicionarModificador(novoItem.armaduraModificador);
		  dano.AdicionarModificador(novoItem.danoModificador);

		}

		if(velhoItem != null)
		{
			armadura.RemoverModificador(velhoItem.armaduraModificador);
			dano.RemoverModificador(velhoItem.danoModificador);
		}
	}

	public override void Die()
	{
		anim.SetTrigger("morto"); 
		base.Die();
		Ref_posiçao_jogador.instance.MatarPlayer(); // se o player estiver sumindo antes de executar a animação, colocar uma coroutine aqui com o tempo da animação de morrer como delay.
	}


	// Update is called once per frame
	void Update()
    {
        
    }
}
