using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SignalingTrigger : MonoBehaviour
{
    [SerializeField] private float _recoveryRate;

    private AudioSource _signalingSound;

    private bool _isSignaling;

    private void Start()
    {
        _signalingSound = GetComponent<AudioSource>();

        _isSignaling = false;
    }

    private void Update()
    {
        if (_isSignaling)
        {
            _signalingSound.volume = Mathf.MoveTowards(_signalingSound.volume, AudioParameters.MaxVolume, _recoveryRate * Time.deltaTime);
        }
        else
        {
            _signalingSound.volume = Mathf.MoveTowards(_signalingSound.volume, AudioParameters.MinVolume, _recoveryRate * Time.deltaTime);
        }

        if (_signalingSound.volume == AudioParameters.MinVolume)
        {
            _signalingSound.Stop();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            _signalingSound.Play();

            _signalingSound.volume += _recoveryRate;

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
