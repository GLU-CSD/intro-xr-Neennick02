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
 
    
    [SerializeField] private AudioSource[] hurtSounds;
    [SerializeField] private AudioSource[] explosionSounds;

    private void Awake()
    {
       
    }

    public void PlayHurtSound()
    {
        //selecteerd een random audioSource uit array
        AudioSource randomHurtSound = hurtSounds[Random.Range(0, hurtSounds.Length)];
        //speelt random audioSource
        randomHurtSound.Play();
    }

    public void PlayExplosionSound()
    {
        //selecteerd een random audioSource uit array
        AudioSource randomExplosionSound = explosionSounds[Random.Range(0, explosionSounds.Length)];
        //speelt random audioSource
        randomExplosionSound.Play();
    }

    public void PlayWinSound()
    {
        winSound.Play();
    }

    public void PlayLoseSound()
    {
        loseSound.Play();
    }
}
