using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;               
    PlayerHealth playerHealth;      
    EnemyHealth enemyHealth;        
    NavMeshAgent nav;               


    void Awake()
    {
        // Set up the references.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //playerHealth = player.GetComponent();
        //enemyHealth = GetComponent();
        nav = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        // If the enemy and the player have health left...
        //if (enemyHealth.currentHealth && playerHealth.currentHealth > 0)
        //{
            // ... set the destination of the nav mesh agent to the player.
            nav.SetDestination(player.position);
        //}
        // Otherwise...
        //else
        //{
            // ... disable the nav mesh agent.
            //nav.enabled = false;
        //}
    }
}