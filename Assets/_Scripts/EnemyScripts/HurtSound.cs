using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class HurtSound : MonoBehaviour
{
    [SerializeField] private AudioClip[] hurtSound;
    [SerializeField] private AudioClip[] explosionSound;

    private AudioSource audioSource;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            Debug.Log("audio source added to object");
        }
        else
        {
            Debug.Log("audio source found on object");
        }
    }

    public void RandomHurtSound()
    {
        //assigned een random clip uit de array
        AudioClip clip = hurtSound[UnityEngine.Random.Range(0, hurtSound.Length)];
        Debug.Log($"Selected clip: {clip.name}");
        //speelt clip af op audioSource
        audioSource.PlayOneShot(clip);
        Debug.Log("sound played");
    }

    public void RandomProjectileSound()
    {
        //assigned een random clip uit de array
        AudioClip clip = explosionSound[UnityEngine.Random.Range(0, explosionSound.Length)];
        Debug.Log($"Selected clip: {clip.name}");
        //speelt clip af op audioSource
        audioSource.PlayOneShot(clip);
        Debug.Log("explosion sound played");
    }
}
