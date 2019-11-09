[System.Serializable]
public class Missao
{
    public bool estaAtiva;

    public string titulo;
    public string descricao;
    public int recompensaOuro;

    public ObjetivoMissao objetivo;

    public void concluida()
    {
        estaAtiva = false;
    }
}
