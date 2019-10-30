using UnityEngine;
using System.IO;
using System.Xml.Serialization;

public class SaveLoad : MonoBehaviour
{
    #region Singleton
    public static SaveLoad instancia;

    private void Awake()
    {
        if(instancia != null)
        {
            Debug.LogWarning("Mais de uma instancia de SaveLoad encontrada!");
            return;
        }
        instancia = this;

        DontDestroyOnLoad(this.gameObject);
    }
    #endregion

    public Criptografia cripto;

    ControladorPersonagem controladorPersonagem;

    private void Start()
    {
        controladorPersonagem = ControladorPersonagem.instancia;
        cripto = new Criptografia();
    }
    public void salvarPlayer()
    {
        controladorPersonagem.personagem.posicao = controladorPersonagem.player.transform.position;

        XmlSerializer serializador = new XmlSerializer(typeof(Player));
        StreamWriter arqDados = new StreamWriter("Player.xml");
        serializador.Serialize(arqDados.BaseStream, controladorPersonagem.personagem);
        arqDados.Close();

        cripto.criptografarArquivo("PlayerPosicao.xml", '§');
        Debug.Log("salvei e criptografei o player");
    }
    public void carregarPlayer()
    {
        cripto.descriptografarArquivo("PlayerPosicao.xml", '§');

        XmlSerializer serializador = new XmlSerializer(typeof(Player));
        StreamReader arqLeit = new StreamReader("Player.xml");
        Player aux = (Player)serializador.Deserialize(arqLeit.BaseStream);
        arqLeit.Close();
        Debug.Log("carreguei o player");


        controladorPersonagem.personagem.posicao = aux.posicao;
        controladorPersonagem.player.transform.position = controladorPersonagem.personagem.posicao;
    }

    public void sairJogo()
    {
        Application.Quit();
    }

    public void Add(System.Object ot)
    {
        throw new FileNotFoundException();
    }
}
