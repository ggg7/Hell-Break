using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour {

    public GameObject Door;
    public bool isPressed;
    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        if (isPressed == true)
        {
            anim.SetTrigger("DoorOpen");
            anim.SetTrigger("SwitchFlipped");
        }
	}
	
	// Update is called once per frame
	void KeyPressed()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            isPressed = true;
        }
    }
}
