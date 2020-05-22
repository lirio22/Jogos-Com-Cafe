using UnityEngine;

public class AreaMusica : MonoBehaviour
{
    [SerializeField] private AudioClip _musica;

    private void OnTriggerEnter2D(Collider2D other)
    {
        TrocaDeMusica.Instancia.TrocarParaMusicaSecundaria(_musica);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        TrocaDeMusica.Instancia.TrocarParaMusicaPrincipal();
    }
}
