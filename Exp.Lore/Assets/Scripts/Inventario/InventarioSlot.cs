using UnityEngine;
using UnityEngine.UI;

public class InventarioSlot : MonoBehaviour
{    
    public Image icon;
    public Image iconeExcluir;

    Item item;

	public void AddItem (Item newItem)
	{
		item = newItem;

		icon.sprite = item.icon;
		icon.enabled = true;
        iconeExcluir.enabled = true;
	}

	public void ClearSlot ()
	{
		item = null;

		icon.sprite = null;
		icon.enabled = false;
        iconeExcluir.enabled = false;
    }

    public void OnRemoveButton()
    {
        Inventario.instance.Remove(item);
    }

    public void UseItem()
	{
		if (item != null)
		{
			item.Use();
		}
	}
}
