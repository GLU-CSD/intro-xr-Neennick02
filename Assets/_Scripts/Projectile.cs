using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 50f;
    private Transform target;

    public GameObject explosionPrefab;
    //[SerializeField] private SoundScript sounds;

    [SerializeField] private AudioClip[] clips;
    [SerializeField] private AudioSource source;

    [SerializeField] private HurtSound hurtSound;

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
            Explode();
            RandomExplosionSound();
            //verwijderd projectile
            Destroy(gameObject);
        }
    }

    void Explode()
    {
            // Instantiate eventuele effecten
            GameObject explosion = Instantiate(explosionPrefab, target.position, Quaternion.identity);
            //explosie geluid
                //RandomExplosionSound();


            //doet damage
            target.GetComponent<Health>().TakeDamage(damage);
    }

    void RandomExplosionSound()
    {
        AudioClip explosionSounds = clips[UnityEngine.Random.Range(0, clips.Length)];
        source.PlayOneShot(explosionSounds);
    }
}
