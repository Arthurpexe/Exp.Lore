using System.Collections.Generic;

public class Lista{
	
	public ElementoLista primeiro, ultimo;
    public int contador;
	
	public Lista(){//cria uma nova lista

		ultimo = primeiro = new ElementoLista(null);
        contador = 0;
	}
	
	public void inserir(Item novoItem){//insere um novo dado no final da lista 

        ElementoLista novoElemento = new ElementoLista(novoItem);
        ultimo.proximo = novoElemento;
		novoElemento.anterior = ultimo;
		ultimo = novoElemento;
        
        contador++;
        novoElemento.endereco = ultimo.endereco = contador;
    }
	
	public Item retirar(Item itemRetirado){//retorna o dado, seja ele qual for, para o programa processa-lo como quiser 
        ElementoLista auxRet;

		auxRet = localizarPorItem(itemRetirado);
		
		ElementoLista auxAnterior = auxRet.anterior;
		if(auxRet != ultimo){
			ElementoLista auxProximo = auxRet.proximo;
			
			auxAnterior.proximo = auxProximo;
			auxProximo.anterior = auxAnterior;
            auxRet.proximo = null;
		}else{
			auxAnterior.proximo = null;
            ultimo = auxAnterior;
		}
        auxRet.anterior = null;

		if(auxRet != null)
        {
            contador--;
            ultimo.endereco = contador;
        }
		return auxRet.meuItem;
        
	}
	
	public ElementoLista localizarPorEndereco(int endereco)
    {//localiza o elemento, e o retorna, sem fazer nada com ele
		if(vazia())
			return null;
		
		ElementoLista aux = primeiro.proximo;

		while(aux != null || aux.endereco != endereco){
			aux = aux.proximo;
		}
		return aux;
	}

    public ElementoLista localizarPorItem(Item itemRetirado)
    {//localiza o elemento, e o retorna, sem fazer nada com ele
        if (vazia())
            return null;

        ElementoLista aux = primeiro.proximo;
        while (aux != null || aux.meuItem != itemRetirado)
        {
            aux = aux.proximo;
        }
        return aux;
    }

    public bool vazia(){//checa se a lista esta vazia
		if(primeiro.proximo == null)
			return true;
		else
			return false;
	}

    public Item[] imprimirLista()
    {
        Item[] itens = new Item[contador+1];
        ElementoLista aux = primeiro.proximo;
        for(int i = 0; i < contador + 1; i++)
        {
            itens[i] = aux.meuItem;
        }
        return itens;
    }
}

	