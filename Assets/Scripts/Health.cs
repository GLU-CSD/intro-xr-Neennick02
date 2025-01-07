using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Image healthbarFill;
     void Start()
    {
        currentHealth = maxHealth;
        UpdateHeathBar();
    }

    void UpdateHeathBar()
    {
        healthbarFill.fillAmount = currentHealth / maxHealth;
    }
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0,maxHealth);
        UpdateHeathBar();
    }
    public void RestoreHealth(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0,maxHealth);
        UpdateHeathBar();
    }
}
