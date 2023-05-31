using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(SignalingTrigger))]
public class TriggerEnterChecker : MonoBehaviour
{
    private SignalingTrigger _signalingTrigger;

    private void Start()
    {
        _signalingTrigger = GetComponent<SignalingTrigger>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _signalingTrigger.EnableAlarm();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _signalingTrigger.DisableAlarm();
        }
    }
}
