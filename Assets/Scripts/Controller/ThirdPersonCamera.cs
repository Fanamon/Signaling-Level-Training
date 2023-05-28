using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private Transform _player;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _orientation;
    [SerializeField] private Transform _playerObject;
    [SerializeField] private float _rotationSpeed;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        Vector3 viewDirection = _player.position - new Vector3(transform.position.x, _player.position.y, transform.position.z);

        _orientation.forward = viewDirection.normalized;

        float horizontalInput = Input.GetAxis(AxisName.Horizontal);
        float verticalInput = Input.GetAxis(AxisName.Vertical);

        Vector3 inputDirection = _orientation.forward * verticalInput + _orientation.right * horizontalInput;

        if (inputDirection !=  Vector3.zero)
        {
            _playerObject.forward = Vector3.Slerp(_playerObject.forward, inputDirection.normalized, _rotationSpeed * Time.deltaTime);
        }
    }
}
