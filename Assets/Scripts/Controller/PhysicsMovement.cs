using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SurfaceSlider))]
public class PhysicsMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private SurfaceSlider _surfaceSlider;

    public event UnityAction<float> Moved;

    public float Speed => _speed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _surfaceSlider = GetComponent<SurfaceSlider>();

        _rigidbody.freezeRotation = true;
    }

    public void Move(Vector3 direction)
    {
        Vector3 directionAlongSurface = _surfaceSlider.Project(direction.normalized);
        Vector3 offset = directionAlongSurface * (Speed * Time.deltaTime);

        _rigidbody.MovePosition(_rigidbody.position + offset);
        Moved?.Invoke(offset.magnitude);
    }
}
