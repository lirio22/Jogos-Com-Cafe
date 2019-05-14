using UnityEngine;

public class MovimentoCarroComTransform : MonoBehaviour
{
     [SerializeField] private Transform[] waypoints;
     private int index = 0; 

     private float distancia = 0.05f;
     private Quaternion direcao;
     private float velocidade = 5;

     private void Update()
     {
         Movimento();
     }

     private void Movimento()
     {
         transform.up = waypoints[index].position - transform.position;
         transform.position = Vector3.MoveTowards(transform.position, waypoints[index].position, velocidade * Time.deltaTime);

         if (Vector3.Distance(transform.position, waypoints[index].position) <= distancia)
         {
             index++;
             if(index == waypoints.Length)
             {
                 index = 0;
             }
         }
     }
}
