using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PassarOMouse : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    public GameObject painelDescricaoItem;
    bool mouseDentro = false;

    void Update()
    {
        if (mouseDentro)
        {
            painelDescricaoItem.SetActive(true);
        }
        else
        {
            painelDescricaoItem.SetActive(false);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseDentro = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        mouseDentro = false;
    }
}
