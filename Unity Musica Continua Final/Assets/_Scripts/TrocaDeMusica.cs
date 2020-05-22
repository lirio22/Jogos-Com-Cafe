using System.Collections;
using UnityEngine;

public class TrocaDeMusica : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSourcePrincipal;
    [SerializeField] private AudioSource _audioSourceSecundario;

    [SerializeField] private Animator _animator;

    public static TrocaDeMusica Instancia;

    private void Awake()
    {
        Instancia = this;
    }

    public void TrocarParaMusicaSecundaria(AudioClip musica)
    {
        //Coloca a música no audio source secundário
        _audioSourceSecundario.clip = musica;

        //Pega o tempo da música principal
        _audioSourceSecundario.time = _audioSourcePrincipal.time;

        //Toca a música secundária
        _audioSourceSecundario.Play();

        //Troca para a música secundária
        _animator.Play("musicaSecundaria_entra");

        //Chama Coroutine para parar a música principal
        StartCoroutine(PararAudioSource(_audioSourcePrincipal));
    }    

    public void TrocarParaMusicaPrincipal()
    {
        //Pega o tempo da música secundária
        _audioSourcePrincipal.time = _audioSourceSecundario.time;

        //Toca a música principal
        _audioSourcePrincipal.Play();

        //Troca para a música principal
        _animator.Play("musicaPrincipal_entra");

        //Chama Coroutine para parar a música secundária
        StartCoroutine(PararAudioSource(_audioSourceSecundario));
    }

    private IEnumerator PararAudioSource(AudioSource audioSource)
    {
        //Espera 1 segundo para esperar acabar a transição
        yield return new WaitForSeconds(0.5f);
        audioSource.Stop();
    }
}