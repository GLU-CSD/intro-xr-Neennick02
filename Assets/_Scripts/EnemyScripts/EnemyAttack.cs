using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Utilities.Tweenables.Primitives;

public class EnemyAttack : MonoBehaviour
{
    public float damageAmount = 10f; //schade per aanval
    public float attackCoolDown = 2f; //tijd tussen aanvallen
    private float lastAttackTime; //tijd sinds laatste aanval

    private Health baseHealth; //health script voor base

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerBase"))
        {
            baseHealth = collision.gameObject.GetComponent<Health>();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerBase"))
        {
            baseHealth = null;
            //verwijderd de reference als vijand base verlaat
        }
    }

    private void Update()
    {
        if (baseHealth != null && Time.time >= lastAttackTime + attackCoolDown)
        {
            baseHealth.TakeDamage(damageAmount); //doet schade
            lastAttackTime = Time.time; //past tijd aan sinds laatste aanval
            Debug.Log(this.name + "attacked your base!");
        }
    }
}
