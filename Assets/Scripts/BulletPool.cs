using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : ObjectPool
{
    //public Bullet bullet;
    //[Range(10, 100)] public int capacity = 20;

    //public Queue<Bullet> objectPool;
    //Queue<Bullet> objectsInGame;

    void Start()
    {
        Initialize();
    }

    private void Update()
    {
        //Debug.Log(objectPool.Count);
        //Pull();
    }

    //public void Initialize()
    //{
    //    objectPool = new Queue<Bullet>(capacity);
    //    objectsInGame = new Queue<Bullet>(capacity);
    //    Debug.Log($"<size=30>{objectPool.Count}</size>");
    //    for (var i = 0; i < capacity; i++)
    //    {
    //        var instance = Instantiate(bullet, transform);
    //        //instance.Pool = this;
    //        instance.gameObject.SetActive(false);
    //        objectPool.Enqueue(instance);
    //    }
    //}

    //public Bullet Pull()
    //{
    //    Debug.LogWarning("Object pulled");
    //    Bullet bullet;
    //    if (objectsInGame.Count < capacity)
    //    {
    //        Debug.Log("NOT Dequeue");
    //        bullet = objectPool.Dequeue();
    //        Debug.Log("Dequeue");
    //        bullet.Enable();
    //        //bullet.SetUp(transform.position, Quaternion.LookRotation(transform.forward, Vector3.up));
    //        objectsInGame.Enqueue(bullet);
            
    //    }
    //    else
    //    {
    //        bullet = objectsInGame.Dequeue();
    //        bullet.Enable();

    //        objectsInGame.Enqueue(bullet);
    //    }
        

    //    return bullet;
    //}
}
