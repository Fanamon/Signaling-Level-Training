using UnityEngine;

[RequireComponent(typeof(PhysicsMovement))]
public class PlayerMovementAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private PhysicsMovement _physicsMovement;

    private void Awake()
    {
        _physicsMovement = GetComponent<PhysicsMovement>();
    }

    private void OnEnable()
    {
        _physicsMovement.Moved += OnMoved;
    }

    private void OnDisable()
    {
        _physicsMovement.Moved -= OnMoved;
    }

    private void OnMoved(float speed)
    {
        _animator.SetFloat(AnimationParameter.SpeedParameterName, speed);
    }
}
