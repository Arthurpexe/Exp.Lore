using UnityEngine;

public class InventarioHUD : MonoBehaviour
{
    public Transform itemsParent;

    public GameObject painelInventario;

    Inventario inventario;

    InventarioSlot[] slots;
    void Start()
    {
        inventario = Inventario.instance;
        inventario.onItemChangedCallback += atualizarHUD;

        slots = GetComponentsInChildren<InventarioSlot>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Inventario"))
        {
            abrirPainel(painelInventario);
        }
    }

    public void atualizarHUD()
    {
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
        Debug.Log("Mudei a HUD");
    }


    public void abrirPainel(GameObject painel)
    {
        painel.SetActive(!painel.activeSelf);
    }
}
