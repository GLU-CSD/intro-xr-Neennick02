using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundScript : MonoBehaviour
{
    [SerializeField] private AudioSource cheers;
    [SerializeField] private AudioSource winSound;
    [SerializeField] private AudioSource loseSound;

    public void PlayWinSound()
    {
        winSound.Play();
    }

    public void PlayLoseSound()
    {
        loseSound.Play();
    }
}
