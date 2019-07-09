using UnityEngine;
using TMPro;

public class ExemploTecladoNumerico : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resposta;
    [SerializeField] private TextMeshProUGUI campoSenha;

    public void DarResposta()
    {
        if(campoSenha.text == "9453")
        {
            resposta.text = "Senha correta!";
        }
        else
        {
            resposta.text = "Senha errada!";
        }
    }
}
