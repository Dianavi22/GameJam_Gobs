using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] TimerManager _timer;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioSource _audioSourceSound;
    [SerializeField] AudioClip _alert;
    [SerializeField] bool isAlarm = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_timer.seconds <= 15)
        {
            _audioSource.pitch = 1.3f;
            if (!isAlarm)
            {
                _audioSourceSound.PlayOneShot(_alert, 0.5f);
                isAlarm = true;
            }
        }
    }
}
