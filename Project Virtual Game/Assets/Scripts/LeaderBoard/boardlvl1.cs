using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class boardlvl1 : MonoBehaviour {

    public LB_Leaderboard leaderBoard;

    private string nameInput = "";

    // flag to say whether or not the latest score is a new high score
    private bool newHighScore;

    // our final score from the last game
    private int finalGameScore;

    public Text UIText_rank;
    public Text UIText_name;
    public Text UIText_score;

    /// <summary>
    /// scene loading
    /// </summary>
    public void Back()
    {
        SceneManager.LoadScene(2);
    }

    private void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex == 5)
        {
            leaderBoard.SetUpScores(0);

            finalGameScore = PlayerPrefs.GetInt("Finalscore");

            newHighScore = leaderBoard.DidGetHighScore(finalGameScore);

            UpdateUIText();
        }

        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            leaderBoard.SetUpScores(1);

            finalGameScore = PlayerPrefs.GetInt("Finalscore");

            newHighScore = leaderBoard.DidGetHighScore(finalGameScore);

            UpdateUIText();
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ResetBoard();
        }
        Cursor.visible = true;

    }

    private void UpdateUIText()
    {
        UIText_rank.text = "";
        UIText_name.text = "";
        UIText_score.text = "";

        for (int i = 1; i <= leaderBoard.numberOfScores; i++)
        {
            // rank
            UIText_rank.text = UIText_rank.text + i.ToString() + ".\n";

            // name
            UIText_name.text = UIText_name.text + leaderBoard.GetNameAt(i) + "\n";

            // score
            UIText_score.text = UIText_score.text + leaderBoard.GetScoreAt(i).ToString() + "\n";

        }
    }

    public void ResetBoard()
    {
        leaderBoard.ResetAllScores();

        UpdateUIText();
    }
}
