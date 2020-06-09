using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text text;
    int score;
    public static ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreManager = this;
    }

    
    public void Increment()
    {
        score += 10;
        PlayerPrefs.SetInt("bestScore", score);
        PlayerPrefs.Save();
        text.text = "Score: " + score;
    }
}
