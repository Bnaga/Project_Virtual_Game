using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingCyl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//transform.RotateAround (Vector3.zero, Vector3.up, 360.0f * Time.deltaTime / 10.0f);
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player")
			col.transform.parent = transform;
	}

	void OnTriggerExit(Collider col)
	{
		if (col.tag == "Player")
			col.transform.parent = null;
	}
}
