using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    #region Singleton
    public static Inventario instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Mais de uma instancia de Inventario encontrada!");
            return;
        }
        instance = this;

    }
    #endregion

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
