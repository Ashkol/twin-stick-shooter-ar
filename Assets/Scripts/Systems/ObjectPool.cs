using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public ObjectPoolItem poolItem;
    [Range(1, 100)] public int capacity = 20;

    public List<ObjectPoolItem> unusedObjects;
    public List<ObjectPoolItem> objectsInGame;

    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        unusedObjects = new List<ObjectPoolItem>(capacity);
        objectsInGame = new List<ObjectPoolItem>(capacity);
        Debug.Log($"<size=30>{unusedObjects.Count}</size>");
        for (var i = 0; i < capacity; i++)
        {
            var instance = Instantiate(poolItem, transform);
            instance.pool = this;
            instance.gameObject.SetActive(false);
            unusedObjects.Add(instance);
        }
    }

    public ObjectPoolItem Acquire()
    {
        Debug.LogWarning("Object acuired");
        if (unusedObjects.Count > 0)
        {
            var item = unusedObjects[0];
            unusedObjects.RemoveAt(0);
            item.Enable();
            objectsInGame.Add(item);
            return item;
        }
        else
        {
            Release(0);
            return Acquire();
        }
    }

    public void Release(ObjectPoolItem item)
    {
        Debug.LogWarning("Object released");
        item.Disable();
        unusedObjects.Add(item);
        objectsInGame.Remove(item);
    }

    public void Release(int index)
    {
        Debug.LogWarning("Object released");
        objectsInGame[index].Disable();
        unusedObjects.Add(objectsInGame[index]);
        objectsInGame.RemoveAt(index);
    }
}
