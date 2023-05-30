using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SignalingTrigger))]
public class TriggerEnterChecker : MonoBehaviour
{
    private SignalingTrigger _signalingTrigger;

    private bool _isSignaling;

    private void Start()
    {
        _signalingTrigger = GetComponent<SignalingTrigger>();
    }

    private void Update()
    {
        if (_isSignaling)
        {
            _signalingTrigger.ChangeSoundVolume(AudioParameters.MaxVolume);
        }
        else
        {
            _signalingTrigger.ChangeSoundVolume(AudioParameters.MinVolume);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _signalingTrigger.PlaySound();

            _isSignaling = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _isSignaling = false;
        }
    }
}
