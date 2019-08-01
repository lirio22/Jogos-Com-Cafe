using UnityEngine;

public class Temporizador : MonoBehaviour
{
    [SerializeField] BarraHorizontal barraHorizontal;
    [SerializeField] BarraCircular barraCircular;

    [SerializeField] private float tempoMaximo;
    private float tempoAtual;

    private bool ligado;

    private void Start()
    {
        tempoAtual = tempoMaximo;
        barraHorizontal.DefinirValorMaximo(tempoMaximo);
        barraCircular.DefinirValorMaximo(tempoMaximo);
    }

    private void Update()
    {
        if(ligado)
        {
            tempoAtual -= Time.deltaTime;

            barraHorizontal.AtualizarBarra(tempoAtual);
            barraCircular.AtualizarBarra(tempoAtual);

            if (tempoAtual <= 0)
            {
                ligado = false;
            }
        }        
    }

    public void ReiniciaTemporizador()
    {
        barraHorizontal.AtualizarBarra(tempoMaximo);
        barraCircular.AtualizarBarra(tempoMaximo);
        tempoAtual = tempoMaximo;
        ligado = false;
    }

    public void IniciaTemporizador()
    {
        ligado = true;
    }
}