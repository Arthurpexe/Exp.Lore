public class ElementoListaItem{
	
	public ElementoListaItem proximo,anterior;
	public Item meuItem;
    public int endereco;
	
	public ElementoListaItem(Item novoItem){//cria um novo elemento
		proximo = anterior = null;
		meuItem = novoItem;
        endereco = 0;
	}
}