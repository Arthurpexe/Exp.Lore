using UnityEngine;

public class MissoesHUD : MonoBehaviour
{
    ControladorPersonagem controladorPersonagem;

    public MissoesSlot[] slotsMissoes = new MissoesSlot[6];
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
                    if (controladorPersonagem.missoesAtivas[i].estaAtiva == true)
                        slotsMissoes[i].AdicionarMissao(controladorPersonagem.missoesAtivas[i]);
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
