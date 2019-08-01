using UnityEngine;
using UnityEngine.UI;

public class BarraCircular : MonoBehaviour
{
    [SerializeField] private Image barra;

    [SerializeField] private float tamanhoMaximo;
    private float tamanhoAtual;

    private float valorMaximo;

    public void DefinirValorMaximo(float _valorMaximo)
    {
        valorMaximo = _valorMaximo;
    }

    public void AtualizarBarra(float _valorAtual)
    {
        tamanhoAtual = _valorAtual * tamanhoMaximo / valorMaximo;
        barra.fillAmount = tamanhoAtual;
    }
}