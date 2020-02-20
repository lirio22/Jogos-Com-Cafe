using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _balaSpawnPoint;

    [SerializeField] private float _tempoDeEspera;
    private float _tempo;

    private void Update()
    {
        _tempo -= Time.deltaTime;
        if(_tempo <= 0)
        {
            PoolingSystem.Instancia.GetObjeto("Bala", _balaSpawnPoint.position, Quaternion.identity);

            _tempo = _tempoDeEspera;
        }
    }
}
