using System;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private GameObject _objectToFollow;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;    
    }

    public void Spawn()
    {
        var spawnedEnemy = Instantiate(_enemyPrefab.gameObject, _transform);

        if (spawnedEnemy.TryGetComponent(out FollowMovement movement) == false)
        {
            throw new NullReferenceException("FollowMovement required on enemy prefab!");
        }

        movement.SetObjectToFollow(_objectToFollow);
    }
}