using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteragirNPCQuest : Interagivel
{
    public Missao missao;

    public bool aceita = false;
    public GameObject painelAceitarQuest;
    public Text textoTitulo;
    public Text textoDescricao;
    public Text textoOuro;

    public override void Interact()
    {
        base.Interact();

        //conversação

        painelAceitarQuest.SetActive(true);
        textoTitulo.text = missao.titulo;
        textoDescricao.text = missao.descricao;
        textoOuro.text = missao.recompensaOuro.ToString();

    }

    public void aceitarQuest()
    {
        Debug.Log("Adicionei uma nova quest!");
        missao.estaAtiva = true;
        controladorPersonagem.missoesAtivas[controladorPersonagem.contadorMissoesAtivas] = missao;
        controladorPersonagem.contadorMissoesAtivas++;
        controladorPersonagem.mudouMissao();
    }
    public void resposta(bool aceitou)
    {
        if (aceitou)
        {
            aceitarQuest();
        }
        painelAceitarQuest.SetActive(false);
    }
}
