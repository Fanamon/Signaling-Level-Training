using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(PhysicsMovement))]
public class AnimationBySpeed : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private PhysicsMovement _physicsMovement;

    private void Awake()
    {
        _physicsMovement = GetComponent<PhysicsMovement>();
    }

    private void Update()
    {
        bool isButtonPressed = (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S));

        if (isButtonPressed)
        {
            _animator.SetFloat(AnimationParameter.SpeedParameterName, _physicsMovement.Speed);
        }
        else
        {
            _animator.SetFloat(AnimationParameter.SpeedParameterName, AnimationParameter.IdleSpeed);
        }
    }
}
