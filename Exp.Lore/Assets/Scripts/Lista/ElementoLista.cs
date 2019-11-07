using System.Collections.Generic;

public class ElementoLista{
	
	public ElementoLista proximo,anterior;
	public Item meuItem;
    public int endereco;
	
	public ElementoLista(Item novoItem){//cria um novo elemento
		proximo = anterior = null;
		meuItem = novoItem;
        endereco = 0;
	}
}