using System;

[Serializable]
public class QuadradoDados
{
    //Variáveis da coordenada
    public float posicaoX;
    public float posicaoY;
    public int indice;

    //Variáveis da cor
    public float lerp;
    public float corAtualR;
    public float corAtualG;
    public float corAtualB;
    public float proximaCorR;
    public float proximaCorG;
    public float proximaCorB;

    //Construtor vazio
    public QuadradoDados() { }

    //Construtor com dados
    public QuadradoDados(float _posicaoX, float _posicaoY, int _indice, float _lerp, float _corAtualR, float _corAtualG, float _corAtualB, float _proximaCorR, float _proximaCorG, float _proximaCorB)
    {
        posicaoX = _posicaoX;
        posicaoY = _posicaoY;
        indice = _indice;

        lerp = _lerp;
        corAtualR = _corAtualR;
        corAtualG = _corAtualG;
        corAtualB = _corAtualB;        
        proximaCorR = _proximaCorR;
        proximaCorG = _proximaCorG;
        proximaCorB = _proximaCorB;        
    }
}