using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhysicsMovement))]
public class EnemyMovement : MonoBehaviour
{
    private PhysicsMovement _movement;

    private void Awake()
    {
        _movement = GetComponent<PhysicsMovement>();
    }

    private void Update()
    {
        _movement.Move(FindAnyObjectByType<Player>().transform.position - transform.position);
    }
}
