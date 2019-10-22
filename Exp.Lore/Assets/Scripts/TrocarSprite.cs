using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrocarSprite : MonoBehaviour
{

    public GameObject painelMenu;
    public Image imagemIcone;
    public Sprite playSprite, pauseSprite;

    // Update is called once per frame
    void Update()
    {
        if (painelMenu.activeSelf)
            imagemIcone.sprite = pauseSprite;
        else
            imagemIcone.sprite = playSprite;
    }
}
