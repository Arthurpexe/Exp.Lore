using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorStats : PersonagemStats
{
    static Animator anim;
    // Start is called before the first frame update
    void Start()
    {
		ControladorEquipamento.instance.trocaDeEquipamento += TrocaDeEquipamento;
        anim = GetComponentInChildren<Animator>();
    }

    
	void TrocaDeEquipamento (Equipamento novoItem, Equipamento velhoItem)
	{
		if(novoItem != null)
		{
			armadura = armadura + novoItem.armaduraModificador;
			dano = dano + novoItem.danoModificador;

		}

		if(velhoItem != null)
		{
			armadura = armadura - velhoItem.armaduraModificador;
			dano = dano - velhoItem.danoModificador;
		}
	}


	public override void Die()
	{
        anim.SetTrigger("morto");
		base.Die();
		Ref_posiçao_jogador.instance.MatarPlayer();
	}


	// Update is called once per frame
	void Update()
    {
        
    }
}
