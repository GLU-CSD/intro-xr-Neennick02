using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public string prefabTag = "Enemy"; //geeft prefab deze naam
    private Health healthScript;

    void Update()
    {
        if(healthScript == null)
        {
            GameObject spawnPrefab = GameObject.FindWithTag(prefabTag);
            if(spawnPrefab != null)
            {
                healthScript = spawnPrefab.GetComponent<Health>();
            }
        }
    }
    public void DamageButton()
    {
        if(healthScript != null)
        {
            healthScript.TakeDamage(10); // -10 health
        }
    }
    public void HealButton()
    {
        if(healthScript != null)
        {
            healthScript.RestoreHealth(10); //+10 health
        }
    }
}
