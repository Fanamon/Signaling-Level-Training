using UnityEngine;
using UnityEngine.Events;

public class PatrollingPoint : MonoBehaviour
{
    public event UnityAction PointEntered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Patrol patrol))
        {
            PointEntered?.Invoke();
        }
    }
}
