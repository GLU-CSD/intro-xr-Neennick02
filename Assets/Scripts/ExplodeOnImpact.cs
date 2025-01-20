using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;

public class ExplodeOnImpact : MonoBehaviour
{
    public float explosionForce = 500f; //kracht v explosie
    public float explosionRadius = 5f; //radius v explosie
    public float explosionDamage = 10f; //schade v explosie
    public SoundScript sound;

    public GameObject explosionPrefab;
    private void Start()
    {
        sound = GetComponent<SoundScript>();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) //zoekt naar object met tag "enemy"
        {
            Explode();
            if (sound != null)
            {
                sound.PlayExplosionSound();
            }
            //particle effect
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Terrain"))
        {
            //particle effect
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void Explode()
    {
        // Vind alle objecten in de buurt van de explosie
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearbyObject in colliders)
        {
            NavMeshAgent agent = nearbyObject.GetComponent<NavMeshAgent>();
            if (agent != null)
            {
                agent.enabled = false;
            }

            Health healthScript = nearbyObject.GetComponent<Health>();
            if (healthScript != null)
            {
                healthScript.TakeDamage(explosionDamage);
            }
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }

                
    }
}
