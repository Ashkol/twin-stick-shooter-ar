using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWalls : MonoBehaviour
{
    public GameObject[] randomWalls;
    // Start is called before the first frame update
    void Start()
    {
        if (Random.value > 0.25)
            randomWalls[Random.Range(0, randomWalls.Length)].SetActive(true);
    }

  
}
