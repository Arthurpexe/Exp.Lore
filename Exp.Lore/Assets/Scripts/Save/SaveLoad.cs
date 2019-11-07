using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using UnityEngine.SceneManagement;

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

    Criptografia cripto;

    public GameObject personagem;

    ControladorPersonagem controladorPersonagem;

    private void Start()
    {
        cripto = new Criptografia();
        controladorPersonagem = ControladorPersonagem.instancia;
    }

    public void CarregarJogo()
    {
        Time.timeScale = 1;

        carregarPlayer();
    }

    public void salvarPlayer()
    {
        controladorPersonagem.personagem.posicao = controladorPersonagem.player.transform.position;
        controladorPersonagem.personagem.vida = controladorPersonagem.vidaAtual;

        XmlSerializer serializador = new XmlSerializer(typeof(Player));
        StreamWriter arqDados = new StreamWriter("Player.xml");
        serializador.Serialize(arqDados.BaseStream, controladorPersonagem.personagem);
        arqDados.Close();

        cripto.criptografarArquivo("Player.xml", '§');
        Debug.Log("salvei e criptografei o player");
    }
    public void carregarPlayer()
    {
        cripto.descriptografarArquivo("Player.xml", '§');

        XmlSerializer serializador = new XmlSerializer(typeof(Player));
        StreamReader arqLeit = new StreamReader("Player.xml");
        Player aux = (Player)serializador.Deserialize(arqLeit.BaseStream);
        arqLeit.Close();
        Debug.Log("carreguei o player");


        controladorPersonagem.personagem.posicao = aux.posicao;
        controladorPersonagem.player.transform.position = controladorPersonagem.personagem.posicao;

        controladorPersonagem.personagem.vida = aux.vida;
        controladorPersonagem.personagemStats.vidaAtual = controladorPersonagem.personagem.vida;
        controladorPersonagem.personagemStats.carregarVida();

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
