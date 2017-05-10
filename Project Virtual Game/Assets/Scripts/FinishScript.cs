using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishScript : MonoBehaviour {


    public TimerScript timeScript;
    // Use this for initialization
    public int gamePoints = 0;
	void Start ()
    {
        GameObject controller = GameObject.Find("GameController");
        timeScript = controller.GetComponent<TimerScript>();
    }
	
	// Update is called once per frame
	void Update ()
    {
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            timeScript.clockIsStopped = true;
            Debug.Log(timeScript.clockIsStopped);
            gamePoints = timeScript.totalPoints;
            PlayerPrefs.SetInt("Finalscore", gamePoints);
            Debug.Log(PlayerPrefs.GetInt("Finalscore"));
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
