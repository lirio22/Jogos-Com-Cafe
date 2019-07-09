using UnityEngine;
using TMPro;

public class TecladoVirtual : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI campoTexto;

    private void Start()
    {
        campoTexto.text = "";
    }

    public void EntradaDeCaractere(string _caractere)
    {
        campoTexto.text += _caractere;
    }

    public void ApagarCaractere()
    {
        campoTexto.text = campoTexto.text.Substring(0, campoTexto.text.Length - 1);
    }
}