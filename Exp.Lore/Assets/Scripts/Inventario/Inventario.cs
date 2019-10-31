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

	public Lista listaItens;

    public void Start()
    {
        listaItens = new Lista();
    }
    public bool Add (Item item)
	{
		if (!item.isDefaultItem)
        {
            if (listaItens.contador >= space)
            {
                Debug.Log("Sem espaço suficiente no inventário.");
                return false;

            }
            listaItens.inserir(item);

			if(onItemChangedCallback != null)
			   onItemChangedCallback.Invoke();
		}
		return true;
	}

	public void Remove(Item item)
	{
		Item itemremovido = listaItens.retirar(item);

		
        onItemChangedCallback.Invoke();
	}

}
