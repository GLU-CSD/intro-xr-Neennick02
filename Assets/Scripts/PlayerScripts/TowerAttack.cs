using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class TowerAttack : MonoBehaviour
{
    public float fireRate = 1f;
    public GameObject projectilePrefab;
    public Transform firePoint;
    [SerializeField] Health towerHealth;

    public SoundScript sounds;

    private float nextFireTime = 0f;
    private List<Transform> enemiesInRange = new List<Transform>();

    private void Start()
    {
        sounds = GetComponent<SoundScript>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemiesInRange.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy")){
            enemiesInRange.Remove(other.transform);
        }
    }

    Transform GetClosestEnemy()
    {
        Transform closestEnemy = null;
        float shortestDistance = Mathf.Infinity;

        //loopt door alle enemies
        foreach (Transform enemy in enemiesInRange)
        {
            //checkt of enemy niet dood is
            if(enemy != null)
            {
                //check afstand tussen toren en enemy
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.position);
            if(distanceToEnemy < shortestDistance)
                {
                    //vindt dichtsbijzijnde enemy
                    shortestDistance = distanceToEnemy;
                    closestEnemy = enemy;
                }
            }else
            {
                //als enemy dood is verwijder game object
                enemiesInRange.Remove(enemy);
                closestEnemy = null;
                return closestEnemy;
            }
            
        }
        return closestEnemy;
    }


    private void Update()
    {
        if(Time.time >= nextFireTime)
        {
            Transform target = GetClosestEnemy();
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
    }

    private void DestroyTower()
    {
        if(towerHealth != null)
        {
            if (towerHealth.currentHealth < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
