using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTarget : MonoBehaviour {

	public float speed = 1;
	private int direction = 1;

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * speed * direction * Time.deltaTime);
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Direction") {
			if (direction == 1)
				direction = -1;
			else
				direction = 1;
		}
	}
}
