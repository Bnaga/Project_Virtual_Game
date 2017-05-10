using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    private void Start()
    {
        //Destroy(GameObject.Find("GameController"));
    }


    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Leaderboard()
    {
        //SceneManager.LoadScene(3);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}