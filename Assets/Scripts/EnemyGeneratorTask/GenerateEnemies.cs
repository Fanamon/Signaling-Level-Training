using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GenerateEnemies : MonoBehaviour
{
    [SerializeField] private GameObject _objectToSpawn;

    private readonly System.Random _random = new System.Random();

    private Transform[] _spawnPoints;

    private readonly float _spawnInterval = 2;
    private float _spawnTimer = 0;

    private void Start()
    {
        _spawnPoints = GetComponentsInChildren<Transform>().Where(spawnPoint => spawnPoint != transform).ToArray();
    }

    private void Update()
    {
        _spawnTimer += Time.deltaTime;

        if (_spawnTimer >= _spawnInterval)
        {
            SpawnObject();

            _spawnTimer = 0;
        }
    }

    private void SpawnObject()
    {
        int randomSpawnIndex = _random.Next(_spawnPoints.Length);

        GameObject spawnedObject = Instantiate(_objectToSpawn, _spawnPoints[randomSpawnIndex].transform.position, Quaternion.identity);
    }
}