using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class KillGameObject : MonoBehaviour
{
    [SerializeField] private Health healthScript;
    private void Update()
    {
        if (healthScript != null)
        {
                //checkt health
                if (healthScript.currentHealth <= 0)
                {
                    //object wordt verwijderd
                    Destroy(gameObject);
                }

        }
        else
        {
            Debug.Log("healthScript not found");
        }
    }
}

