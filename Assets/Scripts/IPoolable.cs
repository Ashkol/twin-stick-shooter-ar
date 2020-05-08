using UnityEngine;

public interface IPoolable 
{
    void Disable();
    void Enable();
    void SetUp(Vector3 spawnPosition, Quaternion spawnRotation);
}
