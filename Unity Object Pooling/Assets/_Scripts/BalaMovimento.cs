using UnityEngine;

public class BalaMovimento : MonoBehaviour
{
    [SerializeField] private float _velocidade;

    private void Update()
    {
        transform.position += new Vector3(transform.position.x , _velocidade * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Inimigo"))
        {
            gameObject.SetActive(false);
        }
    }
}