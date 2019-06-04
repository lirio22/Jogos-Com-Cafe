using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PokemonDados : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nome;
    [SerializeField] private TextMeshProUGUI descricao;
    [SerializeField] private RawImage sprite;

    public void DefineNome(string _nome)
    {
        nome.text = _nome;
    }

    public void DefineDescricao(string _descricao)
    {
        descricao.text = _descricao;
    }

    public void DefineSprite(Texture2D _sprite)
    {
        sprite.texture = _sprite;
    }
}