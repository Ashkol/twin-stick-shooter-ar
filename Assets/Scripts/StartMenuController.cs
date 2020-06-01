using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public void LoadARScene()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadNormalScene()
    {
        SceneManager.LoadScene(2);
    }
}
