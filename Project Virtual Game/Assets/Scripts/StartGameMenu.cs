using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameMenu : MonoBehaviour
{

    public void Level1()
    {
        SceneManager.LoadScene(4);
    }

    public void Level2()
    {
        SceneManager.LoadScene(5);
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
