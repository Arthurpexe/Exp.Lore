
using UnityEngine;

public class Interagivel : MonoBehaviour
{
	public float radius = 3f;
	public Transform interactionTransform;
	
	public GameObject player;

    public ControladorPersonagem controladorPersonagem;

	public virtual void Interact()
	{
		Debug.Log("CONSEGUIU");
	}

    private void Start()
    {
        controladorPersonagem = ControladorPersonagem.instancia;
    }

    void Update ()
	{
		float distance = Vector3.Distance(player.transform.position, interactionTransform.position);

        if (distance <= radius)
        {
            if (Input.GetButtonDown("Interagir"))
            {
                Interact();
            }
        }
    }
				

		

	


	private void OnDrawGizmosSelected()
	{
		if (interactionTransform == null)
			interactionTransform = transform;

		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(interactionTransform.position, radius);
	}

}
