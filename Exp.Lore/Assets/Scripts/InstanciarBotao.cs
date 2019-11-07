using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarBotao : MonoBehaviour
{
    public GameObject player;
    public bool liga = false;
    public GameObject botaoInteragivel;
    public float radius;
    void Update()
    {
        for (int i = 0; i < this.transform.childCount; i++)
        {
            float distance = Vector3.Distance(player.transform.position, this.transform.GetChild(i).position);

            if (distance < radius)
            {
                liga = true;
            }
            else if(liga)
            {
                liga = false;
            }
        }
        botaoInteragivel.SetActive(liga);
    }
}
