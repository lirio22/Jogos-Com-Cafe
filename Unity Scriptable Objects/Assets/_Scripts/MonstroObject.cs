using UnityEngine;

[CreateAssetMenu(fileName = "Novo Monstro", menuName = "Inimigo/Monstro")]
public class MonstroObject : ScriptableObject
{
    public Sprite sprite;
    public string Nome;
    public int Id;
    public int Nivel;
    public int Hp;
    public int Xp;
    public string Item;

    [TextArea]
    public string Descricao;
}
