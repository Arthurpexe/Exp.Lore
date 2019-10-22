using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Novo Equipamento", menuName = "Inventário/Equipamento")]
public class Equipamento : Item
{
	public EquipamentoSlot equipar;

	public int armadura;
	public int dano;

	public override void Use()
	{
		base.Use();
		ControladorEquipamento.instance.Equipar(this);
		RemoverDoInventario();
	}
}

public enum EquipamentoSlot { Capacete, Peitoral, Pernas, Arma, Escudo, Pés }
