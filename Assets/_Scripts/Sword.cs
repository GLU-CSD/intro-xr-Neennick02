using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sword : MonoBehaviour
{

    private AudioSource stabSound;

    private void Start()
    {
        stabSound = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision != null)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("enemy is hit.");
                stabSound.Play();
                Health health = collision.gameObject.GetComponent<Health>();
                Rigidbody rb = this.GetComponent<Rigidbody>();
                health.TakeDamage(25);

                 if(health.currentHealth <= 0)
                {
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}
