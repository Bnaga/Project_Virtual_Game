using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{

    public int boardIndex;
    public int maxNameLength = 16;
    public int scoreMax = 10;

    public string defaultName = "John Doe";
    public float defaultScore = 0;

    private string[] names;
    private int[] scores;
    private float scoreToSet;

    private int rank;

    public void SetUpBoard(int boardIndex)
    {
        this.boardIndex = boardIndex;
    }

    public void CheckBoards()
    {
        if(PlayerPrefs.GetInt("LeaderBoard" + boardIndex) != 2 )
        {
            BuildTable();

            PlayerPrefs.SetInt("Leaderboard" + boardIndex, 2);
        }

        else
        {
            LoadScores();
        }
    }

    public void ResetScores()
    {
        BuildTable();
    }

    public void BuildTable()
    {
        for (int i = 0; i < scoreMax; i++ )
        {
            PlayerPrefs.SetString(boardIndex + "leaderBoardName" + i, defaultName);
            PlayerPrefs.SetFloat(boardIndex + "leaderBoardScore" + i, defaultScore);
        }

        names = new string[scoreMax];
        scores = new int[scoreMax];

        LoadScores();
    }

    public void LoadScores()
    {
        names = new string[scoreMax];
        scores = new int[scoreMax];

        for (var i = 0; i < scoreMax; i++)
        {
            PlayerPrefs.GetString(boardIndex + "leaderBoardName" + i, names[i]);
            PlayerPrefs.GetFloat(boardIndex + "leaderBoardScore" + i, scores[i]);
        }
    }

    public void SaveScores()
    {
        for (var i = 0; i < scoreMax; i++)
        {
            PlayerPrefs.SetString(boardIndex + "leaderBoardName" + i, names[i]);
            PlayerPrefs.SetFloat(boardIndex + "leaderBoardScore" + i, scores[i]);
        }
    }

    public bool GotHighScore(int score)
    {
        rank = GetRank(score);

        if(rank < scoreMax)
        {
            return true;
        }

        return false;
    }

    public int GetRank(int score)
    {
        rank = scoreMax + 1;
        bool onLeaderBoard = false;


        for (int i = (scoreMax -1); i>=0; i-- )
        {
            if(scores[i] < score)
            {
                rank = i;
                onLeaderBoard = true;
            }
        }

        if (onLeaderBoard)
        {
            return rank;
        }

        else
        {
            return scoreMax + 1;
        }
    }

    public string GetNameAt(int index)
    {
        return names[index - 1];
    }

    public int GetScoreAt(int index)
    {
        int sScore = scores[index - 1];

        return sScore;
    }

    public void SubmitLocalScore(string playerName, int score)
    {
        if(playerName == "")
        {
            playerName = "Anon";
        }

        rank = GetRank(score);

        int[] scoresCopy = new int[scoreMax];
        string[] namesCopy = new string[scoreMax];

        for (var i = (scoreMax - 1); i >= 0; i--)
        {
            if (i > rank)
            {
                scoresCopy[i] = scores[i - 1];
                namesCopy[i] = names[i - 1];
            }
            else if (i == rank)
            {
                scoresCopy[i] = score;
                namesCopy[i] = playerName;
            }
            else
            {
                scoresCopy[i] = scores[i];
                namesCopy[i] = names[i];
            }
        }

        for (int a = 0; a < scoreMax; ++a)
        {
            names[a] = namesCopy[a];
            scores[a] = scoresCopy[a];
        }

        SaveScores();
    }
}
