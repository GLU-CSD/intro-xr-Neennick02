using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class KillGameObject : MonoBehaviour
{
    [SerializeField] private Health healthScript;
    [SerializeField] private HurtSound hurtSound;


    private void Update()
    {
        if (healthScript != null)
        {
            if(hurtSound != null)
            {
                //checkt health
                if (healthScript.currentHealth <= 0)
                {
                    //object wordt verwijderd + hurtsound
                    hurtSound.RandomHurtSound();
                    Destroy(gameObject);
                }
            }
            else
            {
                Debug.Log("hurtSoundScript not found");
            }
        }
        else
        {
            Debug.Log("healthScript not found");
        }
    }
}

