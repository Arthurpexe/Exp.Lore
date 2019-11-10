[System.Serializable]
public class Missao
{
    public bool estaAtiva;

    public string titulo;
    public string descricao;
    public int recompensaOuro;

    public ObjetivoMissao objetivo;

    public Missao()
    {
        estaAtiva = false;
        titulo = "novaMissao";
        descricao = "novaDescricao";
        recompensaOuro = 0;
        objetivo = new ObjetivoMissao();
    }
    public void concluida()
    {
        estaAtiva = false;
    }
}
