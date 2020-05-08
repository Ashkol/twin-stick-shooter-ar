using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnedObject;
    public bool burstSpawning = false;
    [Range(1, 5)] public int spawnNumber = 1;
    [Range(1.0f, 30.0f)] public float spawnTime = 5f;
    public ObjectPool pool;
    public Vector2 spawnOffset;

    bool isSpawning;
    System.Diagnostics.Stopwatch timer;

    void Start()
    {
        timer = new System.Diagnostics.Stopwatch();
        timer.Start();
    }

    private void Update()
    {
        if ((timer.ElapsedMilliseconds / 1000f >= spawnTime) && isSpawning)
            Spawn();
    }
    public void StartSpawning() => isSpawning = true;
    public void StopSpawning() => isSpawning = false;

    void Spawn()
    {
        if (pool != null)
        {
            for (var i = 0; i < (burstSpawning ? spawnNumber : 1); i += (burstSpawning ? spawnNumber : 1))
            {
                if (pool.objectsInGame.Count < pool.capacity)
                {
                    var obj = pool.Acquire();
                    obj.SetUp(transform.position + new Vector3(Random.Range(-spawnOffset.x, spawnOffset.x), 0, Random.Range(-spawnOffset.y, spawnOffset.y)),
                              Quaternion.identity);
                    //Instantiate(spawnedObject, transform.position, Quaternion.identity);
                }
            }
            timer.Restart();
        }
    }
}
