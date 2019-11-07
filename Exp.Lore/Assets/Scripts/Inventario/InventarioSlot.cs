
using UnityEngine;
using UnityEngine.UI;

public class InventarioSlot : MonoBehaviour
{    
    public Image icone;
    public Image botaoExcluir;

	Item item;

	public void AddItem (Item newItem)
	{
		item = newItem;

		icone.sprite = item.icon;
		icone.enabled = true;
        botaoExcluir.enabled = true;
        Debug.Log(Inventario.instance.imprimirNomeDosItens());
    }

	public void ClearSlot ()
	{
		item = null;

		icone.sprite = null;
		icone.enabled = false;
        botaoExcluir.enabled = false;
	}

    public void OnRemoveButton()
    {
        Debug.Log(Inventario.instance.imprimirNomeDosItens());
        Inventario.instance.Remove(item);
        Debug.Log(Inventario.instance.imprimirNomeDosItens());

    }

    public void UseItem()
	{
		if (item != null)
		{
			item.Use();
		}
	}
}
