
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
				

		

	


	private void OnDrawGizmosSelected()
	{
		if (interactionTransform == null)
			interactionTransform = transform;

		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(interactionTransform.position, radius);
	}

}
