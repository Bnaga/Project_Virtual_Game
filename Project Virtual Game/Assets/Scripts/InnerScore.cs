using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InnerScore : MonoBehaviour {

    public TimerScript timeScript;
    public GameControllerScript gamescript;
    // Use this for initialization
    private void Start()
    {
        GameObject controller = GameObject.Find("GameController");
        timeScript = controller.GetComponent<TimerScript>();
        gamescript = controller.GetComponent<GameControllerScript>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "paintBall")
        {
            timeScript.totalPoints += 500;
        }
    }
}
