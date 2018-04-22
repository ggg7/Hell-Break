using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeMechanics : MonoBehaviour {

    public Camera fpsCam;
    public float range;
    public LayerMask myLayerMask;
    public float impactForce = 20f;
    public float damage = 30f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
        {
            Attack();
        }
	}

    void Attack()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range, myLayerMask))
        {
            Debug.Log(hit.transform.name);

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

        }
    }
}
