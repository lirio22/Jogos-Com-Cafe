using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource bgmAudio;
    [SerializeField] private AudioSource sfxAudio;

    public static AudioPlayer instance;

    private void Awake()
    {
        instance = this;
    }

    public void TocarBGM(AudioClip _musica)
    {
        bgmAudio.clip = _musica;
        bgmAudio.Play();
    }

    public void PararBGM()
    {
        bgmAudio.Stop();
    }

    public void TocarSFX(AudioClip _efeitoSonoro)
    {
        sfxAudio.PlayOneShot(_efeitoSonoro);        
    }

    public void PararSFX()
    {
        sfxAudio.Stop();
    }
}