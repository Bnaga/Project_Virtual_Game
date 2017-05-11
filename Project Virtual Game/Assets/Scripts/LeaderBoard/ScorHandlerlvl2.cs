using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScorHandlerlvl2 : MonoBehaviour {

    public LB_Leaderboard leaderBoard;

    private string nameInput = "";

    // flag to say whether or not the latest score is a new high score
    private bool newHighScore;

    // our final score from the last game
    private int finalGameScore;

    public Text UIText_rank;
    public Text UIText_name;
    public Text UIText_score;

    // UI player enter name input field Component
    public InputField playerNameInputField;

    // UI panel for entering player name via keyboard
    public GameObject enterNamePanel;

    /// <summary>
    /// scene loading
    /// </summary>
    public void Nextlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void Start()
    {
        leaderBoard.SetUpScores(1);

        finalGameScore = PlayerPrefs.GetInt("Finalscore");

        newHighScore = leaderBoard.DidGetHighScore(finalGameScore);

        UpdateUIText();

        if (newHighScore && finalGameScore != 0)
        {
            ShowEnterNamePanel();
        }
        else
        {
            HideEnterNamePanel();
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

    public void ShowEnterNamePanel()
    {
        playerNameInputField.characterLimit = leaderBoard.maxNameLength;

        enterNamePanel.SetActive(true);

        playerNameInputField.Select();
    }

    public void HideEnterNamePanel()
    {
        enterNamePanel.SetActive(false);
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

    public void NameSubmit()
    {
        HideEnterNamePanel();

        string nameToSubmit = playerNameInputField.text;

        if (nameToSubmit == "")
        {
            nameToSubmit = "Mr. Dummy";
        }

        leaderBoard.SubmitLocalScore(nameToSubmit, finalGameScore);

        UpdateUIText();

        PlayerPrefs.SetInt("Finalscore", 0);
    }

    public void ResetBoard()
    {
        leaderBoard.ResetAllScores();

        UpdateUIText();
    }
}
