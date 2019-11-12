using UnityEngine;

public class MissoesHUD : MonoBehaviour
{
    ControladorPersonagem controladorPersonagem;

    public MissoesSlot[] slotsMissoesAtivas = new MissoesSlot[6];
    public MissoesSlot[] slotsMissoesConcluidas = new MissoesSlot[6];
    void Start()
    {
        controladorPersonagem = ControladorPersonagem.instancia;
        controladorPersonagem.seMissaoMudarCallback += atualizarMissoesHUD;
    }

    public void atualizarMissoesHUD()
    {
        for (int i = 0; i < controladorPersonagem.missoes.Length; i++)
        {
            if (i <= controladorPersonagem.contadorMissoesAtivas)
            {
                if (controladorPersonagem.missoes[i] != null)
                {
                    if (controladorPersonagem.missoes[i].estaAtiva)
                    {
                        slotsMissoesAtivas[i].AdicionarMissao(controladorPersonagem.missoes[i]);
                    }
                    else if (controladorPersonagem.missoes[i].concluida)
                    {
                        slotsMissoesConcluidas[i].AdicionarMissao(controladorPersonagem.missoes[i]);
                        slotsMissoesAtivas[i].concluirMissao();
                    }
                }
            }
            else
            {
                slotsMissoesAtivas[i].ClearSlot();
            }
            
        }

        Debug.Log("Mudei a HUD das Missoes");
    }
}
