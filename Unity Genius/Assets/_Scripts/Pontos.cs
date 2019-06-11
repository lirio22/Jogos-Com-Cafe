using UnityEngine;
using TMPro;

public class Pontos : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pontosTexto;
    [SerializeField] private TextMeshProUGUI pontosMaxTexto;

    private int pontos;
    private int maxPontos;

    public void AdicionaPontos()
    {
        pontos++;
        pontosTexto.text = pontos.ToString();

        if(pontos > maxPontos)
        {
            maxPontos = pontos;
            pontosMaxTexto.text = "Max: " + maxPontos.ToString();
        }
    }

    public void ReiniciaPontos()
    {
        pontos = 0;
        pontosTexto.text = pontos.ToString();
    }
}