using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class PokedexControle : MonoBehaviour
{
    private const string API_SITE = "https://pokeapi.co/api/v2/";
    private const string POKEMON_NOME = "pokemon/";
    private const string POKEMON_DESC = "pokemon-species/";
    private const string POKEMON_SPRITE = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/";

    private string idPokemon = "1";
    [SerializeField] private TMP_InputField idInput;

    private UnityWebRequest pedido;

    private string jsonResposta;

    private bool podePegar;

    [SerializeField] private PokemonIdentidade pokemonIdentidade;
    [SerializeField] private PokedexDescricaoRaiz pokedexDescricao;
    [SerializeField] private Texture2D sprite;

    [SerializeField] private PokemonDados pokemonDados;

    private void Start()
    {
        StartCoroutine(PegaDados());
    }

    public void PegaPokemon()
    {
        if (podePegar)
        {
            idPokemon = idInput.text;
            idInput.text = "";
            StartCoroutine(PegaDados());
        }
    }

    private IEnumerator PegaDados()
    {
        podePegar = false;
        //Pega nome e ID
        pedido = UnityWebRequest.Get(string.Format("{0}{1}{2}", API_SITE, POKEMON_NOME, idPokemon));

        yield return pedido.SendWebRequest();

        jsonResposta = pedido.downloadHandler.text;

        if (jsonResposta == "Not Found")
        {
            podePegar = true;
            yield break;            
        }
        else
        {
            pokemonIdentidade = JsonUtility.FromJson<PokemonIdentidade>(jsonResposta);
        }

        //Pega descrição
        pedido = UnityWebRequest.Get(string.Format("{0}{1}{2}", API_SITE, POKEMON_DESC, idPokemon));

        yield return pedido.SendWebRequest();

        jsonResposta = pedido.downloadHandler.text;

        pokedexDescricao = JsonUtility.FromJson<PokedexDescricaoRaiz>(jsonResposta);

        //Pega imagem
        pedido = UnityWebRequestTexture.GetTexture(string.Format("{0}{1}{2}", POKEMON_SPRITE, idPokemon, ".png"));

        yield return pedido.SendWebRequest();

        sprite = DownloadHandlerTexture.GetContent(pedido);
        sprite.filterMode = FilterMode.Point;

        InsereDados();
        podePegar = true;
    }

    private void InsereDados()
    {
        pokemonDados.DefineNome(string.Format("#{0} - {1}", pokemonIdentidade.id, pokemonIdentidade.name));
        pokemonDados.DefineDescricao(PegaDescricaoIngles());
        pokemonDados.DefineSprite(sprite);
    }

    private string PegaDescricaoIngles()
    {
        for(int i = 0; i < pokedexDescricao.flavor_text_entries.Length; i++)
        {
            if(pokedexDescricao.flavor_text_entries[i].language.name == "en")
            {
                return pokedexDescricao.flavor_text_entries[i].flavor_text.Replace("\n", " ");
            }
        }
        return null;
    }
}