using System.Collections;
using System.Collections.Generic;
using UnityEditor.AssetImporters;
using UnityEngine;
using UnityEngine.AI;

public class SearchTower: MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform playerTransform;
    private Transform towerTransform;

    private RangeAttribute range;

    private void Start()
    {
        // Vind de NavMeshAgent component
        agent = GetComponent<NavMeshAgent>();

        // Zoek de XR Rig met de tag "Player"
        GameObject player = GameObject.FindGameObjectWithTag("PlayerBase");
        GameObject tower = GameObject.FindGameObjectWithTag("PlayerTower");

        if(tower != null)
        {
            towerTransform = tower.transform;
        }

        if(player != null)
        {
            playerTransform = player.transform;
        }
    }

    private void Update()
    {
      if(playerTransform != null)
        {
            agent.stoppingDistance = 4;
            agent.SetDestination(playerTransform.position);
        }  
      else if(towerTransform != null)
        {
            agent.stoppingDistance = 4;
            agent.SetDestination(playerTransform.position);
        }
    }
}
