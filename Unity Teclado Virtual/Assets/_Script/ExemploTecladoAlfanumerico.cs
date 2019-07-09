using UnityEngine;
using TMPro;

public class ExemploTecladoAlfanumerico : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI resposta;
    [SerializeField] private TextMeshProUGUI campoNome;

    public void DarResposta()
    {
        resposta.text = string.Format("Meu nome é {0}.", campoNome.text);
    }
}
