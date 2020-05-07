using UnityEngine;

public abstract class ObjectPoolItem : MonoBehaviour
{
    BulletPool pool;
    public BulletPool Pool
    {
        private get => pool;
        set { pool = value; }
    }

    public abstract void Disable();
    public abstract void Enable();
    public abstract void SetUp(Vector3 spawnPosition, Quaternion spawnRotation);
}
