using UnityEngine;
using UnityEngine.SceneManagement;

public class Cena : MonoBehaviour
{
    public void MudarCena(int indice)
    {
        SceneManager.LoadScene(indice);
    }
}
