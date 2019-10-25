using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteragirNPC : Interagivel
{
    public bool aceita = false;
    public GameObject painelAceitarQuest;
    public override void Interact()
    {
        base.Interact();

        //conversação

        painelAceitarQuest.SetActive(true);
    }

    public void aceitarQuest()
    {
        Debug.Log("Adicionei uma nova quest!");
        //adicionar quest na lista de quests em andamento
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
