using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	public float health = 50f;
    public int attackDamage = 25;
    public float attackDelay = 1f;
    public Transform Player;
    GameObject player;
    PlayerHealth playerhealth;
    public float moveSpeed = 1f;
    public float stopDistance;
    private Animator anim;
    bool playerInRange;
    float timer;
   
    void Start()
    {
        anim = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        player = GameObject.FindGameObjectWithTag("Player");
        playerhealth = player.GetComponent<PlayerHealth>();
    }
    void OnTriggerEnter(Collider other)
    {
        // If the entering collider is the player...
        if (other.gameObject == player)
        {
            Debug.Log("ColliderEntered");
            // ... the player is in range.
            playerInRange = true;
        }
    }


    void OnTriggerExit(Collider other)
    {
        // If the exiting collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is no longer in range.
            playerInRange = false;
        }
    }
    void Update()
    {
        timer = Time.deltaTime;
        if(Vector3.Distance(transform.position, Player.position) > stopDistance)
        {
            if(health >= 1)
            {
                Walk();
                gameObject.transform.LookAt(Player.transform.position);
                transform.position = Vector3.MoveTowards(transform.position, Player.position, moveSpeed * Time.deltaTime);
            }
        } else if(Vector3.Distance(transform.position, Player.position) < stopDistance)
        {
            transform.position = this.transform.position;
            anim.SetTrigger("Idle01");
        }
        if(timer >= attackDelay && playerInRange && health > 0)
        {
            Attack();
        }        
        if(health == 0)
        {
            anim.SetTrigger("Die");
        }
    }

	public void TakeDamage(float amount)
	{
		health -= amount;
		if(health <= 0)
		{
			Die();
		}
	}

    void Walk()
    {
        anim.SetTrigger("Walk");
    }

	void Die()
	{
        anim.SetTrigger("Die");
	}

    void Attack()
    {
        anim.SetTrigger("Basic Attack");
        timer = 0f;
        if(playerhealth.currentHealth > 0)
        {
            playerhealth.TakeDamage(attackDamage);
        }
    }
}
