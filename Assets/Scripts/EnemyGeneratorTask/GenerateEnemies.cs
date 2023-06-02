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

        StartCoroutine(CountTime());
    }

    private IEnumerator CountTime()
    {
        float spawnInterval = 2;
        
        for (float i = 0; i < spawnInterval; i += Time.deltaTime)
        {
            yield return null;
        }

        SpawnEnemy();

        StartCoroutine(CountTime());
    }

    private void SpawnEnemy()
    {
        int randomSpawnIndex = _random.Next(_spawnPoints.Length);

        Instantiate(_enemyToSpawn.gameObject, _spawnPoints[randomSpawnIndex].transform.position, Quaternion.identity);
    }
}