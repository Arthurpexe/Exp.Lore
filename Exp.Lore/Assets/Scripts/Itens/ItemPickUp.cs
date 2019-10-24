
using UnityEngine;

public class ItemPickUp : Interagivel
{
	public Item item;

	public override void Interact()
	{
		base.Interact();
        Debug.Log("Interagindo com " + item.name);
		PickUp();
	}

	void PickUp()
	{
		Debug.Log("Pegando " + item.name);
		bool wasPickedUp = Inventario.instance.Add(item);

		if(wasPickedUp)
		  Destroy(gameObject);
	}
}
