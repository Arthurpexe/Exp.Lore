using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorHUD : MonoBehaviour
{
    public void abrirInventario(GameObject meuCanvas)
    {
        if (meuCanvas.activeSelf)
        {
            meuCanvas.SetActive(false);
        }
        else
        {
            meuCanvas.SetActive(true);
        }
    }
}
