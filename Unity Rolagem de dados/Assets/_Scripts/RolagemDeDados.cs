using UnityEngine;

public class RolagemDeDados : MonoBehaviour
{
    private System.Random random;

    [SerializeField] private int seed;

    private void Start()
    {
        //Gera um número pro seed
        seed = System.Environment.TickCount;

        //Inicializa o random com o seed gerado
        random = new System.Random(seed);
    }

    public int RolarDado()
    {        
        return random.Next(1, 7);
    }

    //Retorna um Vector3 de acordo com o número do dado. Essa é a rotação do dado para mostrar a face com o número certo
    public Vector3 FaceDoDado(int numeroDoDado)
    {
        switch(numeroDoDado)
        {
            case 1:                
                return new Vector3(0.0f, 0.0f, 0.0f);
            case 2:
                return new Vector3(0.0f, -90.0f, 0.0f);
            case 3:
                return new Vector3(0.0f, -90.0f, -90.0f);
            case 4:
                return new Vector3(0.0f, -90.0f, -180.0f);
            case 5:
                return new Vector3(-180.0f, 0.0f, 0.0f);
            case 6:
                return new Vector3(-90.0f, 0.0f, 0.0f);
            default:
                return Vector3.zero;
        }
    }
}