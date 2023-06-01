using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SignalingTrigger : MonoBehaviour
{
    [SerializeField] private float _recoveryRate;

    private AudioSource _signalingSound;
    private Coroutine _signalingPlayer;

    private float _targetAlarmSoundVolume = AudioParameters.MinVolume;

    private bool _isOnTriggerEnter;

    private void Start()
    {
        _signalingSound = GetComponent<AudioSource>();
    }

    public void EnableAlarm()
    {
        _isOnTriggerEnter = true;

        if (_signalingPlayer == null)
        {
            _signalingPlayer = StartCoroutine(PlaySignaling());
        }
    }

    public void DisableAlarm()
    {
        _isOnTriggerEnter = false;
    }

    private IEnumerator PlaySignaling()
    {
        _signalingSound.Play();

        do
        {
            if (_isOnTriggerEnter)
            {
                ChangeSoundVolume(AudioParameters.MaxVolume);
            }
            else
            {
                ChangeSoundVolume(AudioParameters.MinVolume);
            }

            yield return null;
        }
        while (_signalingSound.volume != _targetAlarmSoundVolume);

        _signalingSound.Stop();

        _signalingPlayer = null;
    }

    private void ChangeSoundVolume(float targetVolume)
    {
        _signalingSound.volume = Mathf.MoveTowards(_signalingSound.volume, targetVolume, _recoveryRate * Time.deltaTime);
    }
}
