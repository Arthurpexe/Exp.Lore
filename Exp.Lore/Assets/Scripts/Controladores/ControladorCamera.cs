using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCamera : MonoBehaviour
{
	public GameObject personagem;

    void Update()
    {
		transform.position = Vector3.Lerp(transform.position, new Vector3(personagem.transform.position.x, personagem.transform.position.y + 9f, personagem.transform.position.z + 10.5f), 6 * Time.deltaTime);
    }

}
