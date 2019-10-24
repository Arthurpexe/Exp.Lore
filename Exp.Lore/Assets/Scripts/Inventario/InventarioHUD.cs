using UnityEngine;

public class InventarioHUD : MonoBehaviour
{
    public Transform itemsParent;

    Inventario inventario;

    InventarioSlot[] slots;
    void Start()
    {
        inventario = Inventario.instance;
        inventario.onItemChangedCallback += mudarHUD;

        slots = GetComponentsInChildren<InventarioSlot>();
    }
    void Update()
    {
        
    }

    public void mudarHUD()
    {
        Debug.Log("MUDANDO A HUD");

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventario.items.Count)
            {
                slots[i].AddItem(inventario.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
