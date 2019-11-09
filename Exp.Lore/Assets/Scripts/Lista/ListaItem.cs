using UnityEngine;

public class ListaItem{
	
	public ElementoListaItem primeiro, ultimo;
    public int contador;
	
	public ListaItem(){//cria uma nova lista

        primeiro = new ElementoListaItem(null);
        ultimo = primeiro;
        
        contador = -1;
	}
	
	public void inserir(Item novoItem){//insere um novo dado no final da lista 

        
        ElementoListaItem novoElemento = new ElementoListaItem(novoItem);
        Debug.Log(novoItem.nome + " Anterior e proximo: " + novoElemento.anterior/*.meuItem.name*/ + ", " + novoElemento.proximo/*.meuItem.name */);
        ultimo.proximo = novoElemento;
        novoElemento.anterior = ultimo;
        ultimo = novoElemento;
        Debug.Log(novoItem.nome + " Anterior e proximo: " + novoElemento.anterior/*.meuItem.name*/ + ", " + novoElemento.proximo/*.meuItem.name */);

        contador++;
        novoElemento.endereco = ultimo.endereco = contador;
    }
	
	public Item retirar(Item itemRetirado){//retorna o dado, seja ele qual for, para o programa processa-lo como quiser 
        ElementoListaItem auxRet;

		auxRet = localizarPorItem(itemRetirado);
		if(auxRet == null)
        {
            Debug.Log("tentando retirar o sentinela");
            return null;
        }

		ElementoListaItem auxAnterior = auxRet.anterior;
        ElementoListaItem auxProximo;

		if(auxRet != ultimo){
			auxProximo = auxRet.proximo;
			
			auxAnterior.proximo = auxProximo;
			auxProximo.anterior = auxAnterior;
            auxRet.proximo = null;
		}else{
			auxAnterior.proximo = null;
            ultimo = auxAnterior;
		}
        auxRet.anterior = null;

        contador--;
        ultimo.endereco = contador;

		return auxRet.meuItem;
	}
	
	public ElementoListaItem localizarPorEndereco(int endereco)//localiza o elemento, e o retorna, sem fazer nada com ele
    {
		if(vazia())
			return null;
		
		ElementoListaItem aux = primeiro.proximo;

		while(aux != null && aux.endereco != endereco){
			aux = aux.proximo;
		}
        if (aux != null)
            return aux;
        else
            return new ElementoListaItem(null);
	}

    public ElementoListaItem localizarPorItem(Item itemRetirado)//localiza o elemento, e o retorna, sem fazer nada com ele
    {
        if (vazia())
            return null;

        ElementoListaItem aux = primeiro.proximo;

        while (aux != null && aux.meuItem != itemRetirado)
        {
            aux = aux.proximo;
        }
        if (aux != null)
            return aux;
        else
            return new ElementoListaItem(null);
    }

    public bool vazia(){//checa se a lista esta vazia
		if(primeiro.proximo == null)
			return true;
		else
			return false;
	}

    public Item[] imprimirLista()
    {
        Item[] itens = new Item[contador];
        ElementoListaItem aux = primeiro.proximo;
        for(int i = 0; i < contador; i++)
        {
            itens[i] = aux.meuItem;
        }
        return itens;
    }
}

	