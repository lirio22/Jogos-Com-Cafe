using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bestiario : MonoBehaviour
{
    [SerializeField] private MonstroObject[] monstros;
    private int _indice = 0;

    [SerializeField] private Image _monstroImage;

    [SerializeField] private TextMeshProUGUI _nome;

    [SerializeField] private TextMeshProUGUI _numero;
    [SerializeField] private TextMeshProUGUI _lv;
    [SerializeField] private TextMeshProUGUI _hp;
    [SerializeField] private TextMeshProUGUI _xp;
    [SerializeField] private TextMeshProUGUI _item;

    [SerializeField] private TextMeshProUGUI _descricao;

    private void Start()
    {
        DefinirDados(monstros[_indice].sprite, monstros[_indice].Nome, monstros[_indice].Id,
                     monstros[_indice].Nivel, monstros[_indice].Hp, monstros[_indice].Xp,
                     monstros[_indice].Item, monstros[_indice].Descricao);
    }

    private void DefinirDados(Sprite sprite, string nome, int id, int lv, int hp, int xp, string item, string descricao)
    {
        _monstroImage.sprite = sprite;
        _nome.text = nome;

        _numero.text = "Nº" + id.ToString();
        _lv.text = "LV: " + lv.ToString();
        _hp.text = "HP: " + hp.ToString();
        _xp.text = "XP: " + xp.ToString();
        _item.text = item;

        _descricao.text = descricao;
    }

    public void MudarPagina(int sentido)
    {
        _indice += sentido;

        if(_indice >= monstros.Length)
        {
            _indice = 0;
        }else if(_indice < 0)
        {
            _indice = monstros.Length - 1;
        }

        DefinirDados(monstros[_indice].sprite, monstros[_indice].Nome, monstros[_indice].Id,
                     monstros[_indice].Nivel, monstros[_indice].Hp, monstros[_indice].Xp,
                     monstros[_indice].Item, monstros[_indice].Descricao);
    }
}