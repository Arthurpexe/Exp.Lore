using UnityEngine;

public class InventarioHUD : MonoBehaviour
{
    public Transform itemsParent;

    public GameObject painelInventario, marcadorNovoItem;
    public GameObject painelMissoes, marcadorNovaMissao;

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

            if (marcadorNovoItem.activeSelf)
                marcadorNovoItem.SetActive(false);
        }
        if (Input.GetButtonDown("Missoes"))
        {
            abrirPainel(painelMissoes);

            if (marcadorNovaMissao.activeSelf)
                marcadorNovaMissao.SetActive(false);
        }
    }

    public void atualizarHUD()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i <= inventario.listaItens.contador)
            {
                if (inventario.listaItens.localizarPorEndereco(i).meuItem != null)
                    slots[i].AddItem(inventario.listaItens.localizarPorEndereco(i).meuItem);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }

        //for(int i = 0; i < 4; i++)????
        //{
            
        //}

        if (!painelInventario.activeSelf)
            marcadorNovoItem.SetActive(true);

        Debug.Log("Mudei a HUD");
    }

    public void abrirPainel(GameObject painel)
    {
        painel.SetActive(!painel.activeSelf);

        if (marcadorNovoItem.activeSelf && painel == painelInventario)
        {
            marcadorNovoItem.SetActive(false);
        }
        if (marcadorNovaMissao.activeSelf && painel == painelMissoes)
        {
            marcadorNovaMissao.SetActive(false);
        }
    }
}
