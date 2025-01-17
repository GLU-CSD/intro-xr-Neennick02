using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTowerAttack : MonoBehaviour
{
    public float fireRate = 1f;
    public GameObject projectilePrefab;
    public Transform firePoint;

    private float nextFireTime = 0f;
    private List<Transform> playerTowersInRange = new List<Transform>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerTower"))
        {
           playerTowersInRange.Add(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerTower"))
        {
           playerTowersInRange.Remove(other.transform);
        }
    }

    Transform GetClosestEnemy()
    {
        Transform closestTower = null;
        float shortestDistance = Mathf.Infinity;

        //loopt door alle enemies
        foreach (Transform tower in playerTowersInRange)
        {
            //checkt of tower niet dood is
            if (tower != null)
            {
                //check afstand tussen enemytoren en playertower
                float distanceToEnemy = Vector3.Distance(transform.position, tower.position);
                if (distanceToEnemy < shortestDistance)
                {
                    //vindt dichtsbijzijnde enemy
                    shortestDistance = distanceToEnemy;
                    closestTower = tower;
                }
            }
            else
            {
                //als enemy dood is verwijder game object
                playerTowersInRange.Remove(tower);
                closestTower = null;
                return closestTower;
            }

        }
        return closestTower;
    }


    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Transform target = GetClosestEnemy();
            if (target != null)
            {
                Shoot(target);
                nextFireTime = Time.time + 1f / fireRate;
            }
        }
    }

    void Shoot(Transform target)
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        projectile.GetComponent<Projectile>().SetTarget(target);
    }
}
