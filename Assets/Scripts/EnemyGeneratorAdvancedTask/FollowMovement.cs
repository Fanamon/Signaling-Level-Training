using UnityEngine;

[RequireComponent(typeof(PhysicsMovement))]
public class FollowMovement : MonoBehaviour
{
    private PhysicsMovement _movement;

    private GameObject _objectToFollow;

    private void Awake()
    {
        _movement = GetComponent<PhysicsMovement>();
    }

    private void Update()
    {
        _movement.Move(_objectToFollow.transform.position - transform.position);
    }

    public void SetObjectToFollow(GameObject objectToFollow)
    {
        _objectToFollow = objectToFollow;
    }
}
