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
    public GameObject falarComQuemMinimapa;
    public GameObject equipsTeste;

    private void Update()
    {
        float distance = Vector3.Distance(player.transform.position, interactionTransform.position);
        if (distance <= radius)
        {
            if(Input.GetButtonDown("Interagir"))
                Interact();
        }
    }

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
            falarComQuemMinimapa.SetActive(true);
            //mudar a cor do NPCQuestMinimapa
        }
        if(missao.titulo == "A Invasão")
        {
            for (int i = 0; i < controladorPersonagem.missoes.Length; i++)
            {
                if (controladorPersonagem.missoes[i].titulo == "Boatos (quase) Inacreditaveis")
                {
                    controladorPersonagem.ouro += controladorPersonagem.missoes[i].recompensaOuro;
                    controladorPersonagem.missoes[i].missaoConcluida();
                    controladorPersonagem.mudouMissao();
                }
            }
        }
    }

    public void aceitarQuest()
    {
        Debug.Log("Adicionei a quest "+missao.titulo+"!");
        this.missao.estaAtiva = true;
        controladorPersonagem.missoes[controladorPersonagem.contadorMissoesAtivas] = this.missao;
        controladorPersonagem.contadorMissoesAtivas++;
        controladorPersonagem.mudouMissao();

        if (missao.titulo == "Começando Bem")
        {
            equipsTeste.SetActive(true);
        }
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
