﻿
using UnityEngine;

[CreateAssetMenu(fileName = "Novo Item", menuName = "Inventário/Item")]
public class Item : ScriptableObject
{
    public string nome = "Novo Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
	GameObject player;
	JogadorStats stats;




    public virtual void Use()
    {

    }


    


	

    public virtual void desequipar()
    {
        //dessequipar o item
    }


    public void RemoverDoInventario()
	{
		Inventario.instance.Remove(this);
        Debug.Log("removi " + this.nome);
	}

}
