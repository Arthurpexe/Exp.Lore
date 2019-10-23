
using UnityEngine;

public class Interagivel : MonoBehaviour
{
	public float radius = 3f;
	public Transform interactionTransform;

	
	public Transform player;

	

	public virtual void Interact()
	{
		Debug.Log("CONSEGUIU");
	}

	 void Update ()
	 {
			float distance = Vector3.Distance(player.position, interactionTransform.position);
			if(distance <= radius)
			{
				Interact();
		
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
