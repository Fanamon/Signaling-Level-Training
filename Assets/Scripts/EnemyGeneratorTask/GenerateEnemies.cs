using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GenerateEnemies : MonoBehaviour
{
    [SerializeField] private Enemy _enemyToSpawn;

    private readonly System.Random _random = new System.Random();

    private Transform[] _spawnPoints;

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<Transform>().Where(spawnPoint => spawnPoint != transform).ToArray();

        StartCoroutine(SpawnWithTimeInterval());
    }

    private IEnumerator SpawnWithTimeInterval()
    {
        float spawnInterval = 2;

        bool isGameGoing = true;
        
        while (isGameGoing)
        {
            SpawnEnemy();

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnEnemy()
    {
        int randomSpawnIndex = _random.Next(_spawnPoints.Length);

        Instantiate(_enemyToSpawn.gameObject, _spawnPoints[randomSpawnIndex].transform.position, Quaternion.identity);
    }
}