using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {

	public GameObject playerToTeleport;
	public Transform teleportTo;

	void OnTriggerStay(Collider col)
	{
		if (col.gameObject.tag == "Player") {
		playerToTeleport.transform.position = teleportTo.transform.position;
		}
	}

}
