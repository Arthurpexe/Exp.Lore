using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Novo Equipamento", menuName = "Inventário/Equipamento")]
public class Equipamento : Item
{
	public EquipamentoSlot equiparSlot;

	public int armaduraModificador;
	public int danoModificador;

	public override void Use()
	{
		base.Use();
		ControladorEquipamento.instance.Equipar(this);
        //colocar noa aba equipamentos no slot referente ao enum EquipamentoSlot
		RemoverDoInventario();
	}
}

public enum EquipamentoSlot { Capacete, Peitoral, Pernas, Pés}
