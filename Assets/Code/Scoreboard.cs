using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    
    void Start()
    {
        if ( PlayerPrefs.GetInt("Score", 0) > PlayerPrefs.GetInt("HighScore", 0) )
        {
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score", 0));
        }

        scoreText.text = "Score: " + PlayerPrefs.GetInt("Score", 0).ToString();
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
}
