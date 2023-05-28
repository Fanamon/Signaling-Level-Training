using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PhysicsMovement))]
public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private Transform _orientation;

    private PhysicsMovement _movement;

    private void Awake()
    {
        _movement = GetComponent<PhysicsMovement>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        float horizontal = Input.GetAxis(AxisName.Horizontal);
        float vertical = Input.GetAxis(AxisName.Vertical);

        _movement.Move(_orientation.forward * vertical + _orientation.right * horizontal);
    }
}
