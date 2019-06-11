using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DesselecionaBotao : MonoBehaviour, IPointerUpHandler
{
    [SerializeField] private Button botao;

    public void OnPointerUp(PointerEventData eventData)
    {
        botao.OnDeselect(null);
    }
}