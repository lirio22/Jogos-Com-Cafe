using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Genius : MonoBehaviour
{
    [SerializeField] private Pontos pontos;

    [SerializeField] private Button[] botoes;
    [SerializeField] private Button botaoAux;

    [SerializeField] private GameObject botaoComecar;

    [SerializeField] private Image[] botoesImage;

    private List<int> sequenciaComputador = new List<int>();    

    private int indiceJogador = 0;

    public void Inicia()
    {
        pontos.ReiniciaPontos();
        sequenciaComputador.Clear();
        JogadaComputador();
        botaoComecar.SetActive(false);
    }

    #region Computador
    private void JogadaComputador()
    {
        StartCoroutine(MostraSequencia());
    }

    private IEnumerator MostraSequencia()
    {
        DesativaBotoes();
        sequenciaComputador.Add(Random.Range(0, 4));

        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < sequenciaComputador.Count; i++)
        {                        
            botoes[sequenciaComputador[i]].Select();
            yield return new WaitForSeconds(0.5f);
            botaoAux.Select();
            yield return new WaitForSeconds(0.2f);
        }
        AtivaBotoes();
    }
    #endregion

    #region Jogador
    public void JogadaJogador(int _botaoPressionado) //0 = azul | 1 = amarelo | 2 = laranja | 3 = verde
    {        
        if(_botaoPressionado == sequenciaComputador[indiceJogador])
        {
            pontos.AdicionaPontos();
            indiceJogador++;
            if(indiceJogador >= sequenciaComputador.Count)
            {
                botaoAux.Select();
                indiceJogador = 0;
                JogadaComputador();
            }
        }
        else
        {
            GameOver();
        }        
    }
    #endregion

    #region GameOver
    private void GameOver()
    {
        StartCoroutine(GameOverSequencia());
    }

    private IEnumerator GameOverSequencia()
    {
        DesativaBotoes();
        for(int i = 0; i < 2; i++)
        {
            botoes[0].Select();
            yield return new WaitForSeconds(0.1f);
            botoes[1].Select();
            yield return new WaitForSeconds(0.1f);
            botoes[3].Select();
            yield return new WaitForSeconds(0.1f);
            botoes[2].Select();
            yield return new WaitForSeconds(0.1f);
        }        
        botaoAux.Select();
        yield return new WaitForSeconds(0.5f);
        botaoComecar.SetActive(true);
    }
    #endregion


    private void DesativaBotoes()
    {
        for(int i = 0; i < botoesImage.Length; i++)
        {
            botoesImage[i].raycastTarget = false;
        }
    }

    private void AtivaBotoes()
    {
        for (int i = 0; i < botoesImage.Length; i++)
        {
            botoesImage[i].raycastTarget = true;
        }
    }
}