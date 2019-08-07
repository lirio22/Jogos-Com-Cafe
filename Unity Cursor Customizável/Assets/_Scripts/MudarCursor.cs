using UnityEngine;
using UnityEngine.EventSystems;

public class MudarCursor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Texture2D hoverCursor;
    [SerializeField] private Vector2 customHotspot;

    private Vector2 defaultHotspot = new Vector2(14, 8);

    public void OnPointerEnter(PointerEventData eventData)
    {
        Cursor.SetCursor(hoverCursor, customHotspot, CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Cursor.SetCursor(null, defaultHotspot, CursorMode.Auto);        
    }
}