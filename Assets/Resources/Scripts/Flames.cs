using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flames : MonoBehaviour {

    public AudioClip FlameClip;
    public AudioSource FireSource;

	// Use this for initialization
	void Start () {
        FireSource.clip = FlameClip;
    }
	
	// Update is called once per frame
	void Update () {
        FireSource.Play();
    }
}
