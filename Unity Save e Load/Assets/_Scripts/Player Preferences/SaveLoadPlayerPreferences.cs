using UnityEngine;

public class SaveLoadPlayerPreferences : MonoBehaviour
{
    [SerializeField] private Quadrado quadrado;
    private QuadradoDados quadradoDados;            

    public void Save()
    {
        quadradoDados = quadrado.GetDados();

        PlayerPrefs.SetFloat("PosicaoX", quadradoDados.posicaoX);
        PlayerPrefs.SetFloat("PosicaoY", quadradoDados.posicaoY);
        PlayerPrefs.SetInt("Indice", quadradoDados.indice);
        PlayerPrefs.SetFloat("Lerp", quadradoDados.lerp);
        PlayerPrefs.SetFloat("CorAtualR", quadradoDados.corAtualR);
        PlayerPrefs.SetFloat("CorAtualG", quadradoDados.corAtualG);
        PlayerPrefs.SetFloat("CorAtualB", quadradoDados.corAtualB);
        PlayerPrefs.SetFloat("ProximaCorR", quadradoDados.proximaCorR);
        PlayerPrefs.SetFloat("ProximaCorG", quadradoDados.proximaCorG);
        PlayerPrefs.SetFloat("ProximaCorB", quadradoDados.proximaCorB);

        PlayerPrefs.Save();
    }

    public void Load()
    {
        if (quadradoDados == null)
        {
            quadradoDados = new QuadradoDados();
        }

        quadradoDados.posicaoX = PlayerPrefs.GetFloat("PosicaoX", 0);
        quadradoDados.posicaoY = PlayerPrefs.GetFloat("PosicaoY", 0);
        quadradoDados.indice = PlayerPrefs.GetInt("Indice", 0);
        quadradoDados.lerp = PlayerPrefs.GetFloat("Lerp", 0);
        quadradoDados.corAtualR = PlayerPrefs.GetFloat("CorAtualR", 1);
        quadradoDados.corAtualG = PlayerPrefs.GetFloat("CorAtualG", 1);
        quadradoDados.corAtualB = PlayerPrefs.GetFloat("CorAtualB", 1);
        quadradoDados.proximaCorR = PlayerPrefs.GetFloat("ProximaCorR", 1);
        quadradoDados.proximaCorG = PlayerPrefs.GetFloat("ProximaCorG", 1);
        quadradoDados.proximaCorB = PlayerPrefs.GetFloat("ProximaCorB", 1);

        quadrado.SetDados(quadradoDados);
    }

    public void ResetPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}