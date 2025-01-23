using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtSound : MonoBehaviour
{
    [SerializeField] private AudioClip[] hurtSound;
    private AudioSource enemySource;
    private void Awake()
    {
        enemySource = GetComponent<AudioSource>();
        if (enemySource == null)
        {
            enemySource = gameObject.AddComponent<AudioSource>();
            Debug.Log("source added");
        }
        else
        {
            Debug.Log("source found");
        }
    }

    public void RandomHurtSound()
    {
        //assigned een random clip uit de array
        AudioClip clip = hurtSound[UnityEngine.Random.Range(0, hurtSound.Length)];
        Debug.Log($"Selected clip: {clip.name}");
        //speelt clip af op audioSource
        enemySource.PlayOneShot(clip);
        Debug.Log("sound played");
    }
}
