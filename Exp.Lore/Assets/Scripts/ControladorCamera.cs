using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCamera : MonoBehaviour
{
	public GameObject Personagem;
	
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.position = Vector3.Lerp(transform.position, new Vector3(Personagem.transform.position.x, Personagem.transform.position.y + 12f, Personagem.transform.position.z - 10), 6 * Time.deltaTime);

	}
}
