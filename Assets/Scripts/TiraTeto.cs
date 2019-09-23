using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiraTeto : MonoBehaviour
{
    public float distCamPersonagem;
    void Update()
    {
        RaycastHit acheiTeto;
        Ray raioTiraTeto = new Ray(transform.position, GetComponentInParent<Transform>().transform.position);
        
        if(Physics.Raycast(raioTiraTeto, out acheiTeto, distCamPersonagem))
        {
            if(acheiTeto.collider.tag == "construcao")
            {
                acheiTeto.transform.GetComponent<Material>().color.a = "0,154676???";
            }
        }
    }
}
