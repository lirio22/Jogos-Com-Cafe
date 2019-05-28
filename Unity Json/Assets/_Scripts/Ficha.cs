using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ficha : MonoBehaviour
{    
    [SerializeField] private TextMeshProUGUI nome;
    [SerializeField] private TextMeshProUGUI idade;
    [SerializeField] private Toggle interrogado;
    [SerializeField] private TextMeshProUGUI itens;    
    
    public void AtribuirDadosDaFicha(string _nome, string _idade, bool _interrogado, string _itens)
    {
        nome.text = _nome;
        idade.text = _idade;
        interrogado.isOn = _interrogado;
        itens.text = _itens;
    }
}