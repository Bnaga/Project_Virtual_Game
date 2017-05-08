using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipperySlope : MonoBehaviour {
    GameObject player;
    Rigidbody playerBody;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerBody = player.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            //playerBody.add
        }
    }
}
