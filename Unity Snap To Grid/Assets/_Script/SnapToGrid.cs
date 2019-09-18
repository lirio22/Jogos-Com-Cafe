using UnityEngine;
using UnityEngine.UI;

public class SnapToGrid : MonoBehaviour
{
    private Objeto objeto;

    [SerializeField] private GridLayoutGroup grade;
    private float gradeLargura;
    private float gradeAltura;
    [SerializeField] private int gradeLinha;
    [SerializeField] private int gradeColuna;    

    private float objetoAlinhamentoX;
    private float objetoAlinhamentoY;

    private float posicaoArredondadaX;
    private float posicaoArredondadaY;

    private float posicaoOriginalX;
    private float posicaoOriginalY;

    private void Start()
    {
        gradeLargura = gradeColuna * grade.cellSize.x;
        gradeAltura = gradeLinha * grade.cellSize.y;
    }

    public void DefineObjeto(Objeto _objeto)
    {
        objeto = _objeto;
        ChecarAlinhamento();
    }

    private void ChecarAlinhamento()
    {
        if(objeto.tamanhoX % 2 != 0 && gradeLinha % 2 != 0 || objeto.tamanhoX % 2 == 0 && gradeLinha % 2 == 0)
        {
            objetoAlinhamentoX = 0.0f;
        }
        else
        {
            objetoAlinhamentoX = 0.5f;
        }
        
        if (objeto.tamanhoY % 2 != 0 && gradeColuna % 2 != 0 || objeto.tamanhoY % 2 == 0 && gradeColuna % 2 == 0)
        {
            objetoAlinhamentoY = 0.0f;
        }
        else
        {
            objetoAlinhamentoY = 0.5f;
        }
    }

    private void ArredondarCoordenadas()
    {

        posicaoArredondadaX = Mathf.Round(objeto.transform.localPosition.x / grade.cellSize.x) * grade.cellSize.x;
        if(objetoAlinhamentoX != 0)
        {
            posicaoOriginalX = objeto.transform.localPosition.x;
            if(posicaoArredondadaX > posicaoOriginalX)
            {
                objetoAlinhamentoX *= -1.0f;
            }
        }

        posicaoArredondadaY = Mathf.Round(objeto.transform.localPosition.y / grade.cellSize.y) * grade.cellSize.y;
        if (objetoAlinhamentoY != 0)
        {
            posicaoOriginalY = objeto.transform.localPosition.y;
            if (posicaoArredondadaY > posicaoOriginalY)
            {
                objetoAlinhamentoY *= -1.0f;
            }
        }
    }

    private bool ChecarBordas()
    {
        if (/*Borda Esquerda*/posicaoArredondadaX + (objetoAlinhamentoX * grade.cellSize.x) > -(gradeLargura / 2) && /*Borda Direita*/posicaoArredondadaX + (objetoAlinhamentoX * grade.cellSize.x) < gradeLargura / 2 && /*Borda Inferior*/posicaoArredondadaY + (objetoAlinhamentoY * grade.cellSize.y) > -(gradeAltura / 2) && /*Borda Superior*/posicaoArredondadaY + (objetoAlinhamentoY * grade.cellSize.y) < gradeAltura / 2)
        {
            return true;
        }
        return false;
    }

    public void Snap()
    {
        ArredondarCoordenadas();
        if (ChecarBordas())
        {
            objeto.transform.localPosition = new Vector2(posicaoArredondadaX + (objetoAlinhamentoX * grade.cellSize.x), posicaoArredondadaY + (objetoAlinhamentoY * grade.cellSize.y));
        }
        else
        {
            objeto.VoltaPosicaoInicial();
        }
    }
}