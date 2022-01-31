using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class AICloud : MonoBehaviour
{
    public NavMeshAgent cloud;
    public Transform player;
    public GameManager gameManager;
    public LayerMask playerLayer;
    bool alreadyAttacked = false;
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        cloud = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, playerLayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, playerLayer);
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
    }

    private void ChasePlayer()
    {
        cloud.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        if (!alreadyAttacked)
        {
            Debug.Log("attack");
            gameManager.EndGame();
        }
        alreadyAttacked = true;
    }
}
