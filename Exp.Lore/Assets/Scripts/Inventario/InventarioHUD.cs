﻿using UnityEngine;

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

        slots = itemsParent.GetComponentsInChildren<InventarioSlot>();
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
            if (i < inventario.items.contador)
            {
                slots[i].AddItem(inventario.items.localizarPorEndereco(i).meuItem);
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
