using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 50f;
    private Transform target;

    public GameObject explosionPrefab;
    [SerializeField] HurtSound explosionSound;
    private float timer = 0;
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
            speed = 0f;
            //geeft explosie geluid uit array
            explosionSound.RandomProjectileSound();
            timer += Time.deltaTime / 1000;
            Explode();
            if(timer > 1f)
            {
                //verwijderd projectile
                Destroy(gameObject);
            }
        }
    }

    void Explode()
    {      
        // Instantiate eventuele effecten
        GameObject explosion = Instantiate(explosionPrefab, target.position, Quaternion.identity);
        //doet damage
        target.GetComponent<Health>().TakeDamage(damage);
    }
}
