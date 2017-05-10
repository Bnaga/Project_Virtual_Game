using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

	public GameObject cylinder;
	public GameObject player;
	public int speed;
	
	// Update is called once per frame
	void Update () {
		cylinder.transform.Rotate (0, speed * Time.deltaTime, 0);
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") {
			//col.transform.parent = transform;
			player.transform.SetParent (cylinder.transform, true);
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (col.tag == "Player")
			col.transform.parent = null;
	}
}
