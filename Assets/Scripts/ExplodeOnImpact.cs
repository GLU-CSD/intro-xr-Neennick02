using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ExplodeOnImpact : MonoBehaviour
{
    public float explosionForce = 500f; //kracht v explosie
    public float explosionRadius = 5f; //radius v explosie
    public float explosionDamage = 10f; //schade v explosie

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) //zoekt naar object met tag "enemy"
        {
            Explode();
            //particle effect
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
