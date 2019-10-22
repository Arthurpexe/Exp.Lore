﻿
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
	new public string name = "New Item";
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
