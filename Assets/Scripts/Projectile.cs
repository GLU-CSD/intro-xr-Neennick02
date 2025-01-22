using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 50f;
    private Transform target;

    public GameObject explosionPrefab;
    public void SetTarget(Transform newTarget)
    {
        //selecteerd een target
        target = newTarget;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = (target.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            Explode();
            //verwijderd projectile
            Destroy(gameObject);
        }
    }

    void Explode()
    {
        // Zoek Health component van target met GetComponent
        // Als Health script gevonden is, gebruik TakeDamage functie
     
            //tagetHealth.TakeDamage(10);
            // Gebruik damage variable
            // Instantiate eventuele effecten
            GameObject explosion = Instantiate(explosionPrefab, target.position, Quaternion.identity);
            target.GetComponent<Health>().TakeDamage(damage);
    }
}
