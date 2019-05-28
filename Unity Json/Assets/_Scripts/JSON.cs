using System.IO;
using UnityEngine;

public class JSON : MonoBehaviour
{
    private StreamReader leitor;
    private StreamWriter escritor;
    [SerializeField] private string json;
    [SerializeField] private PessoaRaiz suspeitos;
    [SerializeField] private Ficha[] ficha;

    private void Start()
    {
        DesserializarJSON();  
    }

    private void DesserializarJSON()
    {
        leitor = new StreamReader(Application.dataPath + "/_Json/Suspeitos.json");
        json = leitor.ReadToEnd();
        suspeitos = JsonUtility.FromJson<PessoaRaiz>(json);

        for (int i = 0; i < suspeitos.suspeitos.Length; i++)
        {
            ficha[i].AtribuirDadosDaFicha(suspeitos.suspeitos[i].nome, suspeitos.suspeitos[i].idade.ToString(), suspeitos.suspeitos[i].interrogado, string.Join(", ", suspeitos.suspeitos[i].itens));
        }
    }

    public void SerializarJSON()
    {
        json = JsonUtility.ToJson(suspeitos);
        escritor = new StreamWriter(Application.dataPath + "/_Json/JsonCriado.json", true);        
        escritor.Write(json);
        escritor.Close();
    }
}