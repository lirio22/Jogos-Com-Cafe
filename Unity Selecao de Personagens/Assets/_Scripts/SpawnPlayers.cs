using UnityEngine;

public class SpawnPlayers : MonoBehaviour
{
    [SerializeField] private GameObject[] playerPrefabs;
    [SerializeField] private Transform[] spawnPoint;

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        //Spawna jogador 1
        Instantiate(playerPrefabs[PlayerPrefs.GetInt("Personagem1")], spawnPoint[0].position, Quaternion.identity);

        //Spawna jogador 2
        Instantiate(playerPrefabs[PlayerPrefs.GetInt("Personagem2")], spawnPoint[1].position, Quaternion.identity);
    }
}