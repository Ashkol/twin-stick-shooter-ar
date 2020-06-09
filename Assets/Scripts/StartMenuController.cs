using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenuController : MonoBehaviour
{
    public Text text;

    public void LoadARScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadNormalScene()
    {
        SceneManager.LoadScene(2);
    }

    public void Start()
    {
        if (PlayerPrefs.HasKey("bestScore"))
            text.text = "Best score: " + PlayerPrefs.GetInt("bestScore");
    }
}
