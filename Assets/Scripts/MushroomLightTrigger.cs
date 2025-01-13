using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomLightTrigger : MonoBehaviour
{
    [SerializeField] private Light mushroomLight;

    private void Awake()
    {
        mushroomLight.enabled = false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //geeft XR rig player tag
        {
            mushroomLight.enabled = true;
            Debug.Log("lights ON");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            mushroomLight.enabled = false;
            Debug.Log("lights OFF");
        }
    }
}
