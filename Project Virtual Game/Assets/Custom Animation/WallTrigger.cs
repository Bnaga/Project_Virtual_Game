using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour {

	public Animator anim;

	void Start () {

		anim = GetComponent<Animator>();

	}

	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player") {
				anim.Play("WallSweep");
		}
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
