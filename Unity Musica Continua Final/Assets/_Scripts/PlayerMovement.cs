using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 6;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x + Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, transform.position.y, transform.position.z);
    }
}