using System;
using UnityEngine;

public class Patrolling : MonoBehaviour
{
    [SerializeField] private Patrol _patrol;
    [SerializeField] private PatrollingPoint[] _patrollingPoints;

    private int _currentPointIndex = 0;

    private void OnEnable()
    {
        _patrollingPoints[_currentPointIndex].PointEntered += OnPointEntered;
        SetPatrolAim();
    }

    private void OnDisable()
    {
        _patrollingPoints[_currentPointIndex].PointEntered -= OnPointEntered;
    }

    private void OnPointEntered()
    {
        OnDisable();
        _currentPointIndex++;

        if (_currentPointIndex == _patrollingPoints.Length)
        {
            _currentPointIndex = 0;
        }

        SetPatrolAim();
        OnEnable();
    }

    private void SetPatrolAim()
    {
        if (_patrol.TryGetComponent(out FollowMovement movement) == false)
        {
            throw new NullReferenceException("FollowMovement required on enemy prefab!");
        }

        movement.SetObjectToFollow(_patrollingPoints[_currentPointIndex].gameObject);
    }
}
