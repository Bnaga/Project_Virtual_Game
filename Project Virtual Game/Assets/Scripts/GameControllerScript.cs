using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    public Text scoreText;
    public int score;
    public int highscore;
    // Use this for initialization
    void Start ()
    {
        DontDestroyOnLoad(this);
        score = 0;
        PlayerPrefs.SetInt("HighScore", 0);
    }

    private void Update()
    {
        UpdateScore();
    }

    // Update is called once per frame
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        highscore = score;
        scoreText.text = score.ToString();
        if (highscore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", highscore);
        }
        //Debug.Log(PlayerPrefs.GetInt("HighScore"));
    }
}
