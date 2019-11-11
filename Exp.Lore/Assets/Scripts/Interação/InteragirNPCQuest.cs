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
    public GameObject botaoAceitarQuest;
    public GameObject falarComQuem;

    public override void Interact()
    {
        base.Interact();
        if(this.missao.estaAtiva || this.missao.concluida)
        {
            //conversação diferente
            return;
        }

        //conversação

        botaoAceitarQuest.GetComponent<Button>().onClick.RemoveAllListeners();
        botaoAceitarQuest.GetComponent<Button>().onClick.AddListener(this.respostaSim);

        painelAceitarQuest.SetActive(true);

        this.textoTitulo.text = this.missao.titulo;
        this.textoDescricao.text = this.missao.descricao;
        this.textoOuro.text = this.missao.recompensaOuro.ToString();
        if(missao.objetivo.tipoObjetivo == TipoObjetivo.falarCom)
        {
            //dialogo de falarComQuem especial da missao
            falarComQuem.GetComponent<InteragirNPCQuest>().enabled = true;
            //mudar a cor do NPCQuestMinimapa
        }
    }

    public void aceitarQuest()
    {
        Debug.Log("Adicionei a quest "+missao.titulo+"!");
        this.missao.estaAtiva = true;
        controladorPersonagem.missoesAtivas[controladorPersonagem.contadorMissoesAtivas] = this.missao;
        controladorPersonagem.contadorMissoesAtivas++;
        controladorPersonagem.mudouMissao();
    }
    public void respostaSim()
    {
        this.aceitarQuest();
        painelAceitarQuest.SetActive(false);
    }
    public void respostaNao()
    {
        painelAceitarQuest.SetActive(false);
    }
}
