using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseState : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] Health health;

    private void Update()
    {
        if (health != null)
        {
            if (gameManager != null)
            {
                if (health.currentHealth <= 0)
                {
                    gameManager.GameWin();
                    Destroy(gameObject);
                }
            }
            else
            {
                Debug.Log("Base has no reference to GameManager");
            }
        }
        else
        {
            Debug.Log("Base has no reference to Health");

        }

    }
}
