using UnityEngine;

public class MovimentoCarroComRigidBody : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    private int index = 0;
    

    [SerializeField] private Rigidbody2D rb;

    private float distancia = 0.05f;
    private float velocidade = 5;
    private Vector2 direcao;

    private void FixedUpdate()
    {
        Movimento();
    }

    private void Movimento()
    {
        transform.up = waypoints[index].position - transform.position;
        direcao = ((Vector2)waypoints[index].position - rb.position).normalized;
        rb.MovePosition(rb.position + direcao * velocidade * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, waypoints[index].position, velocidade * Time.deltaTime);
        if (Vector3.Distance(transform.position, waypoints[index].position) <= distancia)
        {
            index++;
            if (index >= waypoints.Length)
            {
                index = 0;
            }
        }
    }
}