using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 50f;
    private Transform target;

    public GameObject explosionPrefab;
    public GameObject explosionAudioPrefab; 
    private void Start()
    {
    }
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
            GameObject explosionSound = Instantiate(explosionAudioPrefab, target.position, Quaternion.identity);
            Explode();
            Destroy(gameObject);
        }
    }

    void Explode()
    {   
        bool hasBeenInstantiated = false;
        // Instantiate eventuele effecten
        if (!hasBeenInstantiated)
        {
            GameObject explosion = Instantiate(explosionPrefab, target.position, Quaternion.identity);
            hasBeenInstantiated = true;
        }
        //doet damage
        target.GetComponent<Health>().TakeDamage(damage);

    }
}
