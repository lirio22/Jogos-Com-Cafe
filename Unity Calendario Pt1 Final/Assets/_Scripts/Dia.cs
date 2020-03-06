using UnityEngine;
using TMPro;

public class Dia : MonoBehaviour
{
    private TextMeshProUGUI _diaTexto;

    private void Awake()
    {
        _diaTexto = gameObject.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetDiaAtivo(bool ativo)
    {
        _diaTexto.gameObject.SetActive(ativo);
    }

    public void AtualizarDiaTexto(string novoDia)
    {
        _diaTexto.text = novoDia;
    }
}
