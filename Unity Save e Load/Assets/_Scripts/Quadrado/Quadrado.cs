using UnityEngine;
using UnityEngine.UI;

public class Quadrado : MonoBehaviour
{
    //Variáveis do movimento
    [SerializeField] private float velocidade;
    [SerializeField] private Transform[] waypoints;
    private int indice = 0;

    //Variáveis das cores
    [SerializeField] private Image quadrado;
    [SerializeField] private Color corAtual;
    [SerializeField] private Color proximaCor;

    //Variáveis do lerp
    private Color lerpCor;
    private float lerp;

    private void Start()
    {
        //Inicializa as cores com valores aleatórios
        corAtual = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
        proximaCor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
    }

    private void Update()
    {
        Movimento();
        Cor();
    }

    private void Movimento()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, waypoints[indice].localPosition, velocidade * Time.deltaTime);
        if (Vector3.Distance(transform.localPosition, waypoints[indice].localPosition) <= 0.01f)
        {
            indice++;
        }
        if(indice == waypoints.Length)
        {
            indice = 0;
        }
    }

    private void Cor()
    {        
        lerp += Time.deltaTime/2;
        lerpCor = Color.LerpUnclamped(corAtual, proximaCor, lerp);
        quadrado.color = lerpCor;
        if(lerp >= 1.0f)
        {
            lerp = 0;
            corAtual = proximaCor;
            proximaCor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
        }
    }
    
    public QuadradoDados GetDados()
    {
        return new QuadradoDados(transform.localPosition.x, transform.localPosition.y, indice, lerp, corAtual.r, corAtual.g, corAtual.b, proximaCor.r, proximaCor.g, proximaCor.b);
    }

    public void SetDados(QuadradoDados _quadradoDados)
    {
        transform.localPosition = new Vector2(_quadradoDados.posicaoX, _quadradoDados.posicaoY);
        indice = _quadradoDados.indice;

        lerp = _quadradoDados.lerp;
        corAtual = new Color(_quadradoDados.corAtualR, _quadradoDados.corAtualG, _quadradoDados.corAtualB, 1.0f);
        proximaCor = new Color(_quadradoDados.proximaCorR, _quadradoDados.proximaCorG, _quadradoDados.proximaCorB, 1.0f);
    }
}