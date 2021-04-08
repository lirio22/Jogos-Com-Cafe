using System.Collections;
using UnityEngine;
using TMPro;

public class LetraPorLetra : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _texto;
    private float _velocidadeDoTexto = 0.02f;

    public bool EstaMostrando { get; private set; }

    private IEnumerator _coroutineDoEfeito;

    public void MostrarTextoLetraPorLetra(string textoDoDialogo)
    {
        _texto.text = textoDoDialogo;

        _coroutineDoEfeito = EfeitoLetraPorLetra();
        StartCoroutine(_coroutineDoEfeito);
        EstaMostrando = true;
    }

    public void MostrarTextoTodo()
    {
        StopCoroutine(_coroutineDoEfeito);
        _texto.maxVisibleCharacters = _texto.text.Length;

        EstaMostrando = false;
    }

    private IEnumerator EfeitoLetraPorLetra()
    {
        int caracteresTotais = _texto.text.Length;
        _texto.maxVisibleCharacters = 0;

        for (int i = 0; i <= caracteresTotais; i++)
        {
            _texto.maxVisibleCharacters = i;
            yield return new WaitForSeconds(_velocidadeDoTexto);
        }
        EstaMostrando = false;
    }
}