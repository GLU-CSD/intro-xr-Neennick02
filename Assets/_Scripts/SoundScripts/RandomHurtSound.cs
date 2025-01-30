using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomHurtSound : MonoBehaviour
{
    [SerializeField] private AudioClip[] hurtSounds;

    private AudioSource audioSource;

    private float destroytimer = 0f;


    private void Awake()
    {
        //checkt of er een AudioSource GameObject is
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            Debug.Log("hurtAudio source added to prefab");
        }
        else
        {
            Debug.Log("hurtAudio source found on prefab");
        }
        playSound();
    }

    private void Update()
    {
        //zorgt dat gameobject zichzelf destroyd
        destroytimer += Time.deltaTime;
        if (destroytimer > 10f)
        {
            Destroy(gameObject);
        }
    }

    public void playSound()
    {
        //assigned een random clip uit de array
        AudioClip clip = hurtSounds[UnityEngine.Random.Range(0, hurtSounds.Length)];
        Debug.Log($"Selected clip: {clip.name}");
        //speelt clip af op audioSource
        audioSource.PlayOneShot(clip);
        Debug.Log("explosion sound played");

    }
}
