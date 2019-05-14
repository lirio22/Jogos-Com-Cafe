using UnityEngine;

public class DragAndDropSprite : MonoBehaviour
{    
    [SerializeField]private Rigidbody2D rb;
    [SerializeField] private Camera cameraPrincipal;

    private bool estaDentro;
    private bool estaArrastando;

    private void Update()
    {
        if (estaDentro && Input.GetKeyDown(KeyCode.Mouse0))
        {
            estaArrastando = true;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            estaArrastando = false;
        }
    }

    private void FixedUpdate()
    {        
        if(estaArrastando)
        {
            rb.MovePosition(cameraPrincipal.ScreenToWorldPoint(Input.mousePosition));            
        }
    }

    private void OnMouseOver()
    {
        estaDentro = true;
    }

    private void OnMouseExit()
    {
        estaDentro = false;
    }
}