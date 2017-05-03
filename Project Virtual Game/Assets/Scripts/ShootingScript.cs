using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour {

    private float cooldown = 1.0f;
    public Rigidbody bullet;
    private float bulletSpeed = 800.0f;
    private float bulletHealth = 1.0f;
    private float xShot = 0.25f;
    public Transform bulletSpawn;
    private float timeStamp;
    private float coolDown = 1;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (timeStamp <= Time.time)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                cooldown = cooldown + 1;
                Fire();
                timeStamp = Time.time + coolDown;
            }
        }
    }

    void Fire()
    {
        {
            Rigidbody nerfshot = Instantiate(bullet, new Vector3(transform.position.x + xShot, transform.position.y, transform.position.z), bulletSpawn.rotation);
            nerfshot.AddForce(transform.forward * bulletSpeed);
            Destroy(nerfshot.gameObject, bulletHealth);
        }
    }
}
