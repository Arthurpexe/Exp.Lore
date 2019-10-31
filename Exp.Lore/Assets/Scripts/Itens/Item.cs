
using UnityEngine;

[System.Serializable]
public class Item
{
    public string name = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;

	public virtual void Use()
	{
		//usar o item
	}

	public void RemoverDoInventario()
	{
		Inventario.instance.Remove(this);
	}

}
