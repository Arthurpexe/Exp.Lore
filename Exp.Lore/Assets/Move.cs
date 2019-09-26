using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Player capsulePosition;
    // Start is called before the first frame update

    void loadPosition()
    {
        XmlSerializer serializador = new XmlSerializer(typeof(Player));
        StreamReader arqLeit = new StreamReader("capsula.xml");
        Player aux = (Player)serializador.Deserialize(arqLeit.BaseStream);
        arqLeit.Close();
        this.capsulePosition.posicao = aux.posicao;
        transform.position = this.capsulePosition.posicao;
    }
    void savePosition()
    {
        XmlSerializer serializador = new XmlSerializer(typeof(Player));
        StreamWriter arqDados = new StreamWriter("capsula.xml");
        serializador.Serialize(arqDados.BaseStream, capsulePosition);
        arqDados.Close();
    }

    void Start()
    {
        capsulePosition = new Player();
        capsulePosition.posicao = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("s"))
        {
            this.capsulePosition.posicao = transform.position;
            savePosition();
        }

        if (Input.GetKey("l"))
        {
            loadPosition();
        }
        float mult = 3 * Time.deltaTime;

        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");
        Vector3 delta = new Vector3(mult * deltaX, 0, mult * deltaZ);
        transform.position += delta;
    }
    public void Add(System.Object ot)
    {
        throw new FileNotFoundException();
    }
}
