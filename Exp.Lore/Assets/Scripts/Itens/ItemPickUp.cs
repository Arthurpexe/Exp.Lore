
using UnityEngine;

public class ItemPickUp : Interagivel
{
	public Item item;

	public override void Interact()
	{
		base.Interact();
        Debug.Log("Interagindo com " + item.nome);
		PickUp();
	}

	public void PickUp()
	{
		Debug.Log("Pegando " + item.nome);
		bool wasPickedUp = Inventario.instance.Add(item);

		if(wasPickedUp)
		  Destroy(gameObject);
	}
}
