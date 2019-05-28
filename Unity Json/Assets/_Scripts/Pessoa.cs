[System.Serializable]
public class Pessoa
{
    public string nome;
    public int idade;
    public bool interrogado;
    public string[] itens;
}

[System.Serializable]
public class PessoaRaiz
{
    public Pessoa[] suspeitos;
}