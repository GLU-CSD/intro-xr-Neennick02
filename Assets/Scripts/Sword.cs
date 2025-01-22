using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision != null)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("enemy is hit.");
                Health health = collision.gameObject.GetComponent<Health>();
                health.TakeDamage(10);
            }
        }
    }
}
