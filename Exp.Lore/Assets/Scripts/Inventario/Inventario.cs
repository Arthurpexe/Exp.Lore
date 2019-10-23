using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
	public static Inventario instance;

	void Awake ()
	{
		instance = this;
	}

	public delegate void OnItemChanged();
	public OnItemChanged onItemChangedCallback;

	public int space = 20;

	public List<Item> items = new List<Item>();

	public bool Add (Item item)
	{
		if (!item.isDefaultItem)
		{
			if(items.Count >= space)
			{
				Debug.Log("Sem espaço suficiente no inventário.");
				return false;

			}
		    items.Add(item);

			if(onItemChangedCallback != null)
			   onItemChangedCallback.Invoke();
		}
		return true;
	}

	public void Remove(Item item)
	{
		items.Remove(item);

		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();
	}

}
