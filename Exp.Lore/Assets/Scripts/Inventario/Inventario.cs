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

	public Lista items;

    public void Start()
    {
        items = new Lista();
    }
    public bool Add (Item item)
	{
		if (!item.isDefaultItem)
        {
            if (items.contador >= space)
            {
                Debug.Log("Sem espaço suficiente no inventário.");
                return false;

            }
            items.inserir(item);

			if(onItemChangedCallback != null)
			   onItemChangedCallback.Invoke();
		}
		return true;
	}

	public void Remove(Item item)
	{
		items.retirar(item);

		if (onItemChangedCallback != null)
			onItemChangedCallback.Invoke();
	}

}
