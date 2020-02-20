using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _balaSpawnPoint;

    [SerializeField] private float _tempoDeEspera;
    private float _tempo;

    [SerializeField] private GameObject _bala;

    private void Update()
    {
        _tempo -= Time.deltaTime;
        if (_tempo <= 0)
        {
            Instantiate(_bala, _balaSpawnPoint.position, Quaternion.identity);

            _tempo = _tempoDeEspera;
        }
    }
}