using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFixer : MonoBehaviour {

    public TimerScript timeScript;
    bool cursorOn = true;

    void Start()
    {
        GameObject controller = GameObject.Find("GameController");
        timeScript = controller.GetComponent<TimerScript>();
    }
    void Update()
    {
        if (!timeScript.clockIsPaused || !timeScript.clockIsStopped)

        {
            //Cursor.visible = true;
            cursorOn = false;
        }

        else
        {
            //Cursor.visible = false;
            cursorOn = true;
        }

        if(cursorOn)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }
    }
}
