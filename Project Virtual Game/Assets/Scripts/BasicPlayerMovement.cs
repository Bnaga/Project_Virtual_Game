using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerMovement : MonoBehaviour
{

    public float maxSpeed = 10.0f;
    private Rigidbody playerBody;

    // Use this for initialization
    void Start ()
    {
        playerBody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float vertMove = Input.GetAxis("Vertical");
        float horzMove = Input.GetAxis("Horizontal");

        playerBody.AddForce(new Vector3(horzMove * maxSpeed, playerBody.velocity.y, vertMove * maxSpeed));
    }
}
