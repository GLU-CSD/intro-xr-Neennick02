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
    private Button buttonHeal;
    private Button buttonDamage;

    private AudioSource brickSound;


    [SerializeField] private HurtSound hurtSound;


    void Start()
    {
        brickSound = GetComponent<AudioSource>();
        currentHealth = maxHealth;
        UpdateHeathBar();
    }

    void UpdateHeathBar()
    {
        healthbarFill.fillAmount = currentHealth / maxHealth;
    }
    public void TakeDamage(float amount)
    {
        //als dit gameobject een enemy is maakt dan geluid bij damage
        if (this.gameObject.CompareTag("Enemy"))
        {
            hurtSound.RandomHurtSound();
        }
        else if(this.gameObject.CompareTag("PlayerBase") || this.gameObject.CompareTag("EnemyBase") || this.gameObject.CompareTag("PlayerTower"))
        {
            brickSound.Play();
        }
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
