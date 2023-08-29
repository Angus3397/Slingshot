using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text highscore;

    public void Setup(int score) 
    {
        gameObject.SetActive(true);
        highscore.text = "High Score: " + score.ToString();
    }
}
