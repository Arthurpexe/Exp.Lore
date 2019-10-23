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


    private void Start()
    {
        cripto = new Criptografia();
    }
    public void salvarPlayer(Player personagem)
    {
        
        XmlSerializer serializador = new XmlSerializer(typeof(Player));
        StreamWriter arqDados = new StreamWriter("Player.xml");
        serializador.Serialize(arqDados.BaseStream, personagem);
        arqDados.Close();

        cripto.criptografarArquivo("PlayerPosicao.xml", '§');
        Debug.Log("salvei e criptografei o player");
    }
    public Player carregarPlayer()
    {
        cripto.descriptografarArquivo("PlayerPosicao.xml", '§');

        XmlSerializer serializador = new XmlSerializer(typeof(Player));
        StreamReader arqLeit = new StreamReader("Player.xml");
        Player aux = (Player)serializador.Deserialize(arqLeit.BaseStream);
        arqLeit.Close();
        Debug.Log("carreguei o player");
        return aux;
    }

    public void sairJogo()
    {
        Application.Quit();
    }
}
