using UnityEngine;

public class MissoesHUD : MonoBehaviour
{
    ControladorPersonagem controladorPersonagem;

    public MissoesSlot[] slotsMissoes = new MissoesSlot[6];
    public MissoesSlot[] slotsMissoesConcluidas = new MissoesSlot[6];
    void Start()
    {
        controladorPersonagem = ControladorPersonagem.instancia;
        controladorPersonagem.seMissaoMudarCallback += atualizarMissoesHUD;
    }

    public void atualizarMissoesHUD()
    {
        for (int i = 0; i < slotsMissoes.Length; i++)
        {
            if (i <= controladorPersonagem.contadorMissoesAtivas)
            {
                if (controladorPersonagem.missoesAtivas[i] != null)
                {
                    if (controladorPersonagem.missoesAtivas[i].estaAtiva)
                        slotsMissoes[i].AdicionarMissao(controladorPersonagem.missoesAtivas[i]);

                    else if (controladorPersonagem.missoesAtivas[i].concluida)
                    {
                        slotsMissoesConcluidas[i].AdicionarMissao(controladorPersonagem.missoesAtivas[i]);
                        slotsMissoes[i].concluirMissao();
                    }
                }
            }
            else
            {
                slotsMissoes[i].ClearSlot();
            }
            
        }

        Debug.Log("Mudei a HUD das Missoes");
    }
}
