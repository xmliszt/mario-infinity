using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text homeScore;
    public TMP_Text gameScore;
    public TMP_Text gameoverScore;
    public bool ResetPlayerPrefs;

    private int score;
    private int highScore;
    // Start is called before the first frame update
    void Start()
    {
        if (ResetPlayerPrefs)
        {
            PlayerPrefs.DeleteAll();
        }
        score = 0;
        highScore = PlayerPrefs.GetInt("high_score", 0);
        UpdateUIScore();
        
    }

    public void AddScore(int value)
    {
        score += value;
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("high_score", highScore);
        }
        UpdateUIScore();
    }

    private void UpdateUIScore()
    {
        homeScore.text = string.Format("High Score: {0}", highScore);
        gameScore.text = score.ToString();
        gameoverScore.text = string.Format("Your Score: {0} High Score: {1}", score, highScore);
    }

    public int GetScore()
    {
        return score;
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("high_score", 0);
    }
}
