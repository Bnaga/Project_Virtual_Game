using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedPlatform : MonoBehaviour {

	public GameObject platform;
	private bool isTriggered = false;
	private float platformTime = 2.0f;

	// Update is called once per frame
	void Update () {
		if (isTriggered) {
			platformTime -= Time.deltaTime;
			if (platformTime < 0) {
				platform.SetActive (false);
			}
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") 
			isTriggered = true;
		
	}
}
