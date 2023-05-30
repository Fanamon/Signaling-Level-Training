using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SignalingTrigger : MonoBehaviour
{
    [SerializeField] private float _recoveryRate;

    private AudioSource _signalingSound;

    public void PlaySound()
    {
        _signalingSound.Play();

        _signalingSound.volume += _recoveryRate;
    }

    public void ChangeSoundVolume(float targetVolume)
    {
        _signalingSound.volume = Mathf.MoveTowards(_signalingSound.volume, targetVolume, _recoveryRate * Time.deltaTime);

        if (_signalingSound.volume == AudioParameters.MinVolume)
        {
            _signalingSound.Stop();
        }
    }

    private void Start()
    {
        _signalingSound = GetComponent<AudioSource>();
    }
}
