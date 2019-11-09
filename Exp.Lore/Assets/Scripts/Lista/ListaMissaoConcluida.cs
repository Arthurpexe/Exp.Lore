public class ListaMissaoConcluida
{
    public ElementoListaMissao primeiro, ultimo;
    public int contador;

    public ListaMissaoConcluida()
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

    public Missao[] imprimirMissao()
    {
        Missao[] missoes = new Missao[contador];
        ElementoListaMissao aux = primeiro.proximo;
        for(int i = 0; i < contador; i++)
        {
            missoes[i] = aux.minhaMissao;
        }
        return missoes;
    }
}
