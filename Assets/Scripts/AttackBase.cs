using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBase : MonoBehaviour
{
    public float fireRate = 1f;
    public GameObject projectilePrefab;
    public Transform firePoint;
    [SerializeField] Health towerHealth;
    public SoundScript sounds;

    private float nextFireTime = 0f;
    private List<Transform> baseInRange = new List<Transform>();

    private void Start()
    {
        sounds = GetComponent<SoundScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBase"))
        {
            baseInRange.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("EnemyBase"))
        {
            baseInRange.Remove(other.transform);
        }
    }

    Transform GetClosestBase()
    {
        Transform closestBase = null;
        float shortestDistance = Mathf.Infinity;

        //loopt door alle enemies
        foreach (Transform target in baseInRange)
        {
            //checkt of enemy niet dood is
            if (target != null)
            {
                //check afstand tussen toren en enemy
                float distanceToBase = Vector3.Distance(transform.position, target.position);
                if (distanceToBase < shortestDistance)
                {
                    //vindt dichtsbijzijnde enemy
                    shortestDistance = distanceToBase;
                    closestBase = target;
                }
            }
            else
            {
                //als enemy dood is verwijder game object
                baseInRange.Remove(target);
                closestBase = null;
                return closestBase;
            }

        }
        return closestBase;
    }


    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Transform target = GetClosestBase();
            if (target != null)
            {
                Shoot(target);
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
        DestroyTower();
    }

    void Shoot(Transform target)
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().SetTarget(target);
        //sounds.PlayExplosionSound();
        //
        //
    }

    private void DestroyTower()
    {
        if (towerHealth != null)
        {
            if (towerHealth.currentHealth < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
