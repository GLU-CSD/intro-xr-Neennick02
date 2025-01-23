using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerGrenade : MonoBehaviour
{
    public GameObject towerPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        //controleerd of granaat de grond raakt
        if (collision.gameObject.CompareTag("Terrain"))
        {
            Instantiate(towerPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
