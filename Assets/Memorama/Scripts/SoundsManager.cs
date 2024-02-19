using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _flipCard;

    public void PlaySound(string sound)
    {
        switch (sound)
        {
            case "Button":
                _audioSource.clip = _flipCard[0];
                _audioSource.Play();
                break;
            case "Good":
                _audioSource.clip = _flipCard[1];
                _audioSource.Play();
                break;
            case "Finish":
                _audioSource.clip = _flipCard[2];
                _audioSource.Play();
                break;
        }
    }
}
