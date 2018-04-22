using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour {

    public GameObject destroyedRocks;

    void OnMouseDown()
    {
        Instantiate(destroyedRocks, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    /*public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }*/
}
