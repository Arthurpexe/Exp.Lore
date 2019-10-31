
using UnityEngine;

public class Interagivel : MonoBehaviour
{
	public float radius = 3f;
	public Transform interactionTransform;
	
	public Transform player;

    public bool liga = false;
    public GameObject botaoInteragivel;

    public float distance;
    public virtual void Interact()
	{
		Debug.Log("CONSEGUIU");
	}

	void Update ()
	{
		distance = Vector3.Distance(player.position, interactionTransform.position);

        if (distance <= radius)
        {
            instanciarBotao();
            if (Input.GetButtonDown("Interagir"))
            {
                Interact();
            }
        }
        else
        {
            instanciarBotao();
        }
    }
				
    public void instanciarBotao()
    {


            if (distance < radius)
            {
                liga = true;
            }
            else if(liga)
            {
                liga = false;
            }
        
        botaoInteragivel.SetActive(liga);
    }
		

	


	private void OnDrawGizmosSelected()
	{
		if (interactionTransform == null)
			interactionTransform = transform;

		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(interactionTransform.position, radius);
	}

}
