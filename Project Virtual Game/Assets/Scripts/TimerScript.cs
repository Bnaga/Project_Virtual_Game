using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{

    private float timeRun;
    public bool clockIsPaused = false;
    public bool clockIsStopped = false;
    public Text timeText;

    public Text scoreText;
    int beginPoints = 10000;
    public int totalPoints;
    public GameControllerScript controllerScript;
    public int totPoints;
    // Update is called once per frame

    void Start()
    {
        GameObject controller = GameObject.Find("GameController");
        controllerScript = controller.GetComponent<GameControllerScript>();
    }
    void Update ()
    {
		if(!clockIsPaused && !clockIsStopped)
        {
            timeRun += Time.deltaTime;
            timeRun = Mathf.Round(timeRun * 100.0f) / 100.0f;
            timeText.text = timeRun.ToString();
        }
        TimeToPoints();

        if (Input.GetKeyDown(KeyCode.O))
        {
            clockIsStopped = !clockIsStopped;
            Debug.Log(clockIsStopped);
        }


    }

    void TimeToPoints()
    {
        totPoints = beginPoints - (int)(100 * timeRun);
        if((totPoints%10) == 0)
        {
            totalPoints = totPoints;
        }
        scoreText.text = totalPoints.ToString();
    }
}
