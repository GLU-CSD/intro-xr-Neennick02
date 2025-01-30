using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Image healthbarFill;
    private Button buttonHeal;
    private Button buttonDamage;

    private AudioSource brickSound;

    [SerializeField] Transform spawnPosition;
    [SerializeField] private GameObject hurtSoundPrefab;
    [SerializeField] private GameObject brickSoundPrefab;
 

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
            if(hurtSoundPrefab != null)//checkt of er een prefab aan het gameobject gekoppeld is
            {
                Instantiate(hurtSoundPrefab, spawnPosition.position, spawnPosition.rotation);
            }
        }
        else if(this.gameObject.CompareTag("PlayerBase") || this.gameObject.CompareTag("EnemyBase") || this.gameObject.CompareTag("PlayerTower"))
        {
            if(brickSoundPrefab != null)//checkt of er een prefab aan het gameobject gekoppeld is
            {
                Instantiate(brickSoundPrefab, spawnPosition.position, spawnPosition.rotation);
            }
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
