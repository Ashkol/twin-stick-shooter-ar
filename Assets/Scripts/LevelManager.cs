using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private float levelStartTime;
    int currentLevel = 0;

    public float levelDuration;
    public float minSpawnTime;
    public float spawnTimeProgression;
    float currentSpawnTime;

    public Button[] weaponButtons;
    public Spawner[] zombieSpawners;

    public float startZombieSpeed = 2;
    public float zombieSpeedProgression = 1;
    public static float currentZombieSpeed = 2;

    public Text levelText;


    // Start is called before the first frame update
    void Start()
    {
        levelStartTime = Time.time;
        weaponButtons[0].interactable = true;
        currentSpawnTime = minSpawnTime;
        foreach (Spawner spawner in zombieSpawners)
            spawner.spawnTime = currentSpawnTime;

        levelText.text = "Level:" + (currentLevel + 1);
    }

    // Update is called once per frame
    void Update()
    {

        if(Time.time - levelStartTime > levelDuration && currentLevel < 4)
        {
            levelText.text = "Level:" + (currentLevel + 1);
            currentLevel++;
            weaponButtons[currentLevel].interactable = true;
            currentSpawnTime -= spawnTimeProgression;
            currentZombieSpeed += zombieSpeedProgression;
            levelStartTime = Time.time;

            foreach (Spawner spawner in zombieSpawners)
                spawner.spawnTime = currentSpawnTime;
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
