using UnityEngine;

public class ObjectPoolItem : MonoBehaviour
{
    public ObjectPool pool;

    public virtual void Disable()
    {
        gameObject.SetActive(false);
    }

    public virtual void Enable()
    {
        gameObject.SetActive(true);
    }

    public virtual void SetUp(Vector3 spawnPosition, Quaternion spawnRotation)
    {
        Debug.Log($"Spawn position: {spawnPosition}");
        transform.position = spawnPosition;
        transform.rotation = spawnRotation;
    }
}
