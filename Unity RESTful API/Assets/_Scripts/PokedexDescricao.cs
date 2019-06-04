[System.Serializable]
public class PokedexDescricaoIdioma
{
    public string name;
}

[System.Serializable]
public class PokedexDescricao
{
    public string flavor_text;
    public PokedexDescricaoIdioma language;
}

[System.Serializable]
public class PokedexDescricaoRaiz
{
    public PokedexDescricao[] flavor_text_entries;
}
