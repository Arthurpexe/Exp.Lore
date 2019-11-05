using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PersonagemStats))]
public class VidaHUD : MonoBehaviour
{
    public GameObject vidaPrefab;
    public Transform posicaoBarraVida;
    public Canvas c;

    float tempoVisivel = 5;
    float ultimaVezVisto;
    Transform ui;
    Image barraVida;
    Transform mainCamera;

    void Start()
    {
        mainCamera = Camera.main.transform;

        ui = Instantiate(vidaPrefab, c.transform).transform;
        barraVida = ui.GetChild(0).GetComponent<Image>();
        ui.gameObject.SetActive(false);

        GetComponent<PersonagemStats>().seVidaMudar += seVidaMudar;
    }

    void LateUpdate()
    {
        if (ui != null)
        {
            ui.position = posicaoBarraVida.position;
            ui.forward = -mainCamera.forward;

            if(Time.time - ultimaVezVisto > tempoVisivel)
                ui.gameObject.SetActive(false);
            
        }
    }

    public virtual void seVidaMudar(int vidaMaxima,int vidaAtual)
    {
        if (ui != null)
        {
            ui.gameObject.SetActive(true);
            ultimaVezVisto = Time.time;

            float porcentagemVida = vidaAtual / (float)vidaMaxima;
            barraVida.fillAmount = porcentagemVida;
            if (vidaAtual <= 0)
                Destroy(ui.gameObject);
        }
        else
        {

        }
    }
}
