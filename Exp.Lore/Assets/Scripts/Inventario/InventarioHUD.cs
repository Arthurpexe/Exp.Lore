using UnityEngine;

public class InventarioHUD : MonoBehaviour
{
    public Transform itensParent;
    public Transform equipsParent;

    public GameObject painelInventario, marcadorNovoItem;
    public GameObject painelMissoes, marcadorNovaMissao;

    Inventario inventario;
    ControladorEquipamento controladorEquipamento;

    InventarioSlot[] slotsItens;
    InventarioSlot[] slotsEquips;
    void Start()
    {
        controladorEquipamento = ControladorEquipamento.instance;
        inventario = Inventario.instance;
        inventario.onItemChangedCallback += atualizarInventarioHUD;
        controladorEquipamento.atualizarEquipamento += atualizarEquipsHUD;

        slotsItens = itensParent.GetComponentsInChildren<InventarioSlot>();
        slotsEquips = equipsParent.GetComponentsInChildren<InventarioSlot>();
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
        for (int i = 0; i < slotsItens.Length; i++)
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

        Debug.Log("Mudei a HUD dos Inventarios");
    }

    public void atualizarEquipsHUD()
    {
        for (int i = 0; i < slotsEquips.Length; i++)
        {
            if (controladorEquipamento.equipamentoAtual[i] != null)
            {
                slotsEquips[i].AddItem(controladorEquipamento.equipamentoAtual[i]);
                inventario.Remove(controladorEquipamento.equipamentoAtual[i]); 
            }
            else
            {
                slotsEquips[i].ClearSlot();
            }
        }
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
