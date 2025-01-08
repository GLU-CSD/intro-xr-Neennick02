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

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHeathBar();

        GameObject obj1 = GameObject.Find("TakeDamage"); //koppelt damage button aan enemy prefab
        buttonHeal = obj1.GetComponent<Button>();

        buttonHeal.onClick.AddListener(() => TakeDamage(10));

        GameObject obj2 = GameObject.Find("RestoreHealth");
        buttonDamage = obj2.GetComponent<Button>();

        buttonDamage.onClick.AddListener(() => RestoreHealth(10));
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
