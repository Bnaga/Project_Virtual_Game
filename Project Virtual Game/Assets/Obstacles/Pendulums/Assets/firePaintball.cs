using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* to use, make a new GameObject called "bulletOrigin" and make it a child of Gun (model for the gun we're using.)
 * Attach this script to the Gun object and add "bulletOrigin" to it.
 * paintBallSpeed determines velocity,
 * paintBallDecay determines how many seconds the paintballs stay alive for.
 * paintBallSpeedModifier allows the player to alter the speed of the bullet with Q (+) and E (-) respectively.
 * paintBall Minimum and Maximum set up the velocity boundaries.
 */

public class firePaintball : MonoBehaviour {

    public GameObject bulletOrigin;
    public GameObject paintBall;
    public float paintBallSpeed = 5000;
    public float paintBallSpeedModifier = 1000;
    public float paintBallDecay = 3;
    public float paintBallSpeedMaximum = 10000;
    public float paintBallSpeedMinimum = 1000;

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E) && paintBallSpeed < paintBallSpeedMaximum)
        {
            paintBallSpeed = paintBallSpeed + paintBallSpeedModifier;
        }

        else if (Input.GetKeyDown(KeyCode.Q) && paintBallSpeed > paintBallSpeedMinimum)
        {
            paintBallSpeed = paintBallSpeed - paintBallSpeedModifier;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Instantiate paintBall
            GameObject theBullet;
            theBullet = Instantiate(paintBall, bulletOrigin.transform.position, bulletOrigin.transform.rotation) as GameObject;



            // Retrieve rigidbody.
            Rigidbody rigidBody;
            rigidBody = theBullet.GetComponent<Rigidbody>();

            // Give speed to the bullet.
            rigidBody.AddForce(transform.right * paintBallSpeed);

            // Kill the paintball after defined number of seconds have passed.
            Destroy(theBullet, paintBallDecay);
        }
	}
}
