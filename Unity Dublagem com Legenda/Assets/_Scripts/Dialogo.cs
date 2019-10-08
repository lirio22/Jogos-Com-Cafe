using System.Collections;
using UnityEngine;
using TMPro;

public class Dialogo : MonoBehaviour
{
    //Variáveis do áudio
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] dublagens;

    //Variáveis do texto
    [SerializeField] private TextMeshProUGUI legendaTexto;
    [SerializeField] private string[] legendas;

    //Impede o usuário de iniciar a coroutine até que ela tenha terminado ou parado
    private bool podeTocar = true;

    //Guarda a referência da instância atual da coroutine
    private IEnumerator coroutineAtual;

    public void TocarDialogo()
    {
        if (podeTocar)
        {
            podeTocar = false;
            //Passa a instância atual da coroutine para o coroutineAtual
            coroutineAtual = TocarFala();
            //Inicia a coroutine
            StartCoroutine(coroutineAtual);
        }
    }

    public void PararDialogo()
    {
        //Para a coroutine
        StopCoroutine(coroutineAtual);
        //Para o audio
        audioSource.Stop();
        //Desabilita o texto
        legendaTexto.gameObject.SetActive(false);
        //Permite que a coroutine possa iniciar
        podeTocar = true;
    }

    private IEnumerator TocarFala()
    {
        for (int i = 0; i < dublagens.Length; i++)
        {
            //Passa a dublagem atual para o Audio Source e toca
            audioSource.clip = dublagens[i];
            audioSource.Play();

            //Faz o texto da legenda aparecer e passa a legenda atual para o texto
            legendaTexto.gameObject.SetActive(true);
            legendaTexto.text = legendas[i];

            //Espera o audio da dublagem atual acabar
            yield return new WaitForSeconds(dublagens[i].length);
            //Esconde o texto da dublagem
            legendaTexto.gameObject.SetActive(false);
        }
        //Permite que a coroutine possa iniciar
        podeTocar = true;
    }
}