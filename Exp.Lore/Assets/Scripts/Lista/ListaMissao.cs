public class ListaMissao
{
    public ElementoListaMissao primeiro, ultimo;
    public int contador;

    public ListaMissao()
    {
        primeiro = new ElementoListaMissao(null);
        ultimo = primeiro;

        contador = -1;
    }

    public void inserir(Missao novaMissao)
    {
        ElementoListaMissao novoElemento = new ElementoListaMissao(novaMissao);
        ultimo.proximo = novoElemento;
        novoElemento.anterior = ultimo;
        ultimo = novoElemento;

        contador++;
        novoElemento.endereco = ultimo.endereco = contador;
    }

    public void retirar(Missao missaoRetirada)
    {
        ElementoListaMissao auxRet;

        auxRet = localizarPorMissao(missaoRetirada);
        if(auxRet == null)
        {
            return;
        }

        ElementoListaMissao auxAnterior = auxRet.anterior;
        ElementoListaMissao auxProximo;

        if(auxRet != ultimo)
        {
            auxProximo = auxRet.proximo;

            auxAnterior.proximo = auxProximo;
            auxProximo.anterior = auxAnterior;
            auxRet.proximo = null;
        }
        else
        {
            auxAnterior.proximo = null;
            ultimo = auxAnterior;
        }
        auxRet.anterior = null;

        contador--;
        ultimo.endereco = contador;
    }

    public void concluir()
    {

    }

    public ElementoListaMissao localizarPorEndereco(int endereco)
    {
        if (vazia())
            return null;

        ElementoListaMissao aux = primeiro.proximo;

        while (aux != null && aux.endereco != endereco)
        {
            aux = aux.proximo;
        }
        if (aux != null)
            return aux;
        else
            return new ElementoListaMissao(null);
    }

    public ElementoListaMissao localizarPorMissao(Missao missaoRetirada)//localiza o elemento, e o retorna, sem fazer nada com ele
    {
        if (vazia())
            return null;

        ElementoListaMissao aux = primeiro.proximo;

        while (aux != null && aux.minhaMissao != missaoRetirada)
        {
            aux = aux.proximo;
        }
        if (aux != null)
            return aux;
        else
            return new ElementoListaMissao(null);
    }

    public bool vazia()
    {
        if (primeiro.proximo == null)
            return true;
        else
            return false;
    }
    public Missao[] imprimirMissao()
    {
        Missao[] missoes = new Missao[contador];
        ElementoListaMissao aux = primeiro.proximo;
        for (int i = 0; i < contador; i++)
        {
            missoes[i] = aux.minhaMissao;
        }
        return missoes;
    }
}
