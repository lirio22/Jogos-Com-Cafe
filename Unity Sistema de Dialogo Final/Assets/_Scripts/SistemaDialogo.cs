using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class SistemaDialogo : MonoBehaviour
{
    [SerializeField] private GameObject _caixaDeDialogo;

    [SerializeField] private LetraPorLetra _letraPorLetra;
    [SerializeField] private Animator _animator;
    [SerializeField] private Image _avatarPersonagem;
    [SerializeField] private TextMeshProUGUI _nomePersonagem;

    private Conversa _conversaAtual;
    private int _indiceFalas;
    private Queue<string> _filaFalas;    

    public void IniciarDialogo(Conversa conversa)
    {        
        //Faz aparecer a caixa de diálogo
        _caixaDeDialogo.SetActive(true);

        //Inicializa a fila
        _filaFalas = new Queue<string>();

        _conversaAtual = conversa;
        _indiceFalas = 0;

        ProximaFala();
    }

    public void ProximaFala()
    {
        if(_letraPorLetra.EstaMostrando)
        {
            _letraPorLetra.MostrarTextoTodo();
            return;
        }

        if(_filaFalas.Count == 0)
        {
            if(_indiceFalas < _conversaAtual.Falas.Length)
            {
                //Coloca a imagem do personagem na caixa de diálogo e arruma o tamanho
                _avatarPersonagem.sprite = _conversaAtual.Falas[_indiceFalas].Personagem.Expressoes[_conversaAtual.Falas[_indiceFalas].IdDaExpressao];
                _avatarPersonagem.SetNativeSize();

                //Coloca o nome do personagem na caixa de diálogo
                _nomePersonagem.text = _conversaAtual.Falas[_indiceFalas].Personagem.Nome;

                //Coloca todas as falas da expressão atual em uma fila
                foreach (string textoFala in _conversaAtual.Falas[_indiceFalas].TextoDasFalas)
                {
                    _filaFalas.Enqueue(textoFala);
                }

                _indiceFalas++;
            }
            else
            {
                //Faz sumir a caixa de diálogo
                StartCoroutine(FecharJanela());
                return;
            }
        }

        _letraPorLetra.MostrarTextoLetraPorLetra(_filaFalas.Dequeue());
    }

    private IEnumerator FecharJanela()
    {
        _animator.Play("caixaDialogo_sai");
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        _caixaDeDialogo.SetActive(false);
    }
}