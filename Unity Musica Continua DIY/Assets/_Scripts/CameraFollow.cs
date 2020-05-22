using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private void Update()
    {
        transform.position = new Vector3(_player.position.x, transform.position.y, transform.position.z);
    }
}