using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public Text scoreText;
    //public Text highscoreText;

    public GameOver gameOver;

    int score = 0;
    int highscore = 0;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "Points: " + score.ToString();
        //highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    public void AddPoint() 
    {
        score += 1;
        scoreText.text = "Points: " + score.ToString();
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }

    public void GameOverScreen()
    {
        gameOver.Setup(score);
    }
}
