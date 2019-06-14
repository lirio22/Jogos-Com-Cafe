using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource som;

    public static AudioPlayer instance;

    private void Awake()
    {
        instance = this;
    }

    public void TocarSom(AudioClip _audioClip)
    {
        som.clip = _audioClip;
        som.Play();
    }

    public void PararSom()
    {
        som.Stop();
    }
}