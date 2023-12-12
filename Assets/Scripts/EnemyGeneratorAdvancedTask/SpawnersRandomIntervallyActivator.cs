using System.Collections;
using UnityEngine;

public class SpawnersRandomIntervallyActivator : MonoBehaviour
{
    [SerializeField] private int _spawnInterval = 2;

    [SerializeField] private EnemySpawner[] _spawners;

    private readonly System.Random _random = new System.Random();


    private void Start()
    {
        StartCoroutine(ActivateSpawnerWithTimeInterval());
    }

    private IEnumerator ActivateSpawnerWithTimeInterval()
    {
        int randomSpawnerIndex;

        while (Application.isPlaying)
        {
            randomSpawnerIndex = _random.Next(_spawners.Length);

            _spawners[randomSpawnerIndex].Spawn();

            yield return new WaitForSeconds(_spawnInterval);
        }
    }
}
