using UnityEngine;
using UnityEngine.UI;

public class ControladorHUD : MonoBehaviour
{
    public void abrirInventario(GameObject canvasInventario)
    {
        if (canvasInventario.activeSelf)
        {
            canvasInventario.SetActive(false);
        }
        else
        {
            canvasInventario.SetActive(true);
        }
    }
    public void abrirMenu(GameObject canvasMenu)
    {

        if (canvasMenu.activeSelf)
        {
            canvasMenu.SetActive(false);
        }
        else
        {
            canvasMenu.SetActive(true);
        }
    }
}
