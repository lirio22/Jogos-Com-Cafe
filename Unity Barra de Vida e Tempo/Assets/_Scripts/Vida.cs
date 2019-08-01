using UnityEngine;

public class Vida : MonoBehaviour
{
    [SerializeField] BarraHorizontal barraHorizontal;
    [SerializeField] BarraCircular barraCircular;

    [SerializeField] private int vidaMaxima;
    [SerializeField] private int vidaAtual;

    private void Start()
    {
        vidaAtual = vidaMaxima;
        barraHorizontal.DefinirValorMaximo(vidaMaxima);
        barraCircular.DefinirValorMaximo(vidaMaxima);
    }

    public void AdicionaVida()
    {
        if (vidaAtual < vidaMaxima)
        {
            vidaAtual++;
            barraHorizontal.AtualizarBarra(vidaAtual);
            barraCircular.AtualizarBarra(vidaAtual);
        }
    }

    public void RetiraVida()
    {
        if (vidaAtual > 0)
        {
            vidaAtual--;
            barraHorizontal.AtualizarBarra(vidaAtual);
            barraCircular.AtualizarBarra(vidaAtual);
        }
    }
}