﻿using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour {

	public float health = 100f;

	public void TakeDamage(float amount)
	{
		health -= amount;
		if(health <= 0)
		{
			Die();
		}
	}
	void Die()
	{
        //anim.SetTrigger("isDead");
        Destroy(gameObject, 2f);
	}
}
