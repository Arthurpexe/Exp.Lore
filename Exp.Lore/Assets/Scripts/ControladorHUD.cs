using UnityEngine;
using UnityEngine.UI;

public class ControladorHUD : MonoBehaviour
{
    public void abrirPainel(GameObject painel)
    {

        if (painel.activeSelf)
        {
            painel.SetActive(false);
        }
        else
        {
            painel.SetActive(true);
        }
    }
}
