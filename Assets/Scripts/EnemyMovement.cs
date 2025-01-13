using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform playerTransform;

    private void Start()
    {
        // Vind de NavMeshAgent component
        agent = GetComponent<NavMeshAgent>();

        // Zoek de XR Rig met de tag "Player"
        GameObject player = GameObject.FindGameObjectWithTag("PlayerBase");
        if(player != null)
        {
            playerTransform = player.transform;
        }
    }

    private void Update()
    {
      if(playerTransform != null)
        {
            agent.SetDestination(playerTransform.position);
        }  
    }
}
