using UnityEngine;

public class Objeto : MonoBehaviour
{
    [SerializeField] private SnapToGrid snapToGrid;

    public int tamanhoX;
    public int tamanhoY;

    private Vector2 posicaoInicial;

    private void Start()
    {
        posicaoInicial = transform.localPosition;
    }

    public void VoltaPosicaoInicial()
    {
        transform.localPosition = posicaoInicial;
    }

    private void OnMouseDown()
    {
        snapToGrid.DefineObjeto(this);
    }

    private void OnMouseUp()
    {
        snapToGrid.Snap();
    }
}