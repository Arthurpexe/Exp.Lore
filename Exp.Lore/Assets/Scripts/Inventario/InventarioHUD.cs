using UnityEngine;

public class InventarioHUD : MonoBehaviour
{
    public Transform itensParent;

    public GameObject painelInventario, marcadorNovoItem;
    public GameObject painelMissoes, marcadorNovaMissao;

    Inventario inventario;

    InventarioSlot[] slotsItens;
    void Start()
    {
        inventario = Inventario.instance;
        inventario.onItemChangedCallback += atualizarInventarioHUD;
        slotsItens = itensParent.GetComponentsInChildren<InventarioSlot>();
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

    public void atualizarInventarioHUD()
    {
        for (int i = 1; i < slotsItens.Length; i++)
        {
            if (i <= inventario.listaItens.contador)
            {
                if (inventario.listaItens.localizarPorEndereco(i).meuItem != null)
                    slotsItens[i].AddItem(inventario.listaItens.localizarPorEndereco(i).meuItem);
            }
            else
            {
                slotsItens[i].ClearSlot();
            }
        }

        if (!painelInventario.activeSelf)
            marcadorNovoItem.SetActive(true);
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
