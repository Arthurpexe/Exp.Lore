public class ElementoListaMissao
{
    public ElementoListaMissao proximo, anterior;
    public Missao minhaMissao;
    public int endereco;

    public ElementoListaMissao(Missao novaMissao)
    {
        proximo = anterior = null;
        minhaMissao = novaMissao;
        endereco = 0;
    }
}
