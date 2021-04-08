using UnityEngine;

[CreateAssetMenu(fileName = "Novo Persoangem", menuName = "Dialogo/Personagem")]
public class Personagem : ScriptableObject
{
    public string Nome;
    public Sprite[] Expressoes;
}