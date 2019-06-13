using UnityEngine;

public class ExemploDeUso : MonoBehaviour
{
    [SerializeField] private AudioClip musica1;
    [SerializeField] private AudioClip musica2;

    [SerializeField] private AudioClip efeito1;
    [SerializeField] private AudioClip efeito2;

    public void TocaMusica1()
    {
        AudioPlayer.instance.TocarBGM(musica1);
    }

    public void TocaMusica2()
    {
        AudioPlayer.instance.TocarBGM(musica2);
    }

    public void PararMusica()
    {
        AudioPlayer.instance.PararBGM();
    }

    public void TocaEfeito1()
    {
        AudioPlayer.instance.TocarSFX(efeito1);
    }

    public void TocaEfeito2()
    {
        AudioPlayer.instance.TocarSFX(efeito2);
    }

    public void PararEfeito()
    {
        AudioPlayer.instance.PararSFX();
    }
}