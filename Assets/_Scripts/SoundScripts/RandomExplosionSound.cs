using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomExplosionSound: MonoBehaviour
{
    [SerializeField] private AudioClip[] explosionSound;

    private AudioSource audioSource;

    private float destroytimer = 0f;


    private void Awake()
    {
        //checkt of er een AudioSource GameObject is
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            Debug.Log("explosionAudio source added to prefab");
        }
        else
        {
            Debug.Log("explosionAudio source found on prefab");
        }
        RandomProjectileSound();
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
