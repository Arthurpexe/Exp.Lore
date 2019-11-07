using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorItem : MonoBehaviour
{
    public Item meuItem;
    public Sprite ItemSprite;
    void Start()
    {
        meuItem = new Item();
        meuItem.name = "blalal";
        meuItem.icon = ItemSprite;
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            Debug.Log("Tentando adicionar");
            meuItem.Use();
        }
            
    }
}
