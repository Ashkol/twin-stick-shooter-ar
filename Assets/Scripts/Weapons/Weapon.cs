using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponStats stats;
    public GameObject weaponModel;
    public Transform bulletOriginPoint;

    int ammoLeftInClip;

    void Start()
    {
        ammoLeftInClip = stats.clipCapacity;
        transform.localPosition = stats.positionOffset;
        transform.localRotation = Quaternion.Euler(stats.rotationEulerAngles);
        //bulletPool = FindObjectOfType<BulletPool>();
    }

    public void Shoot(Vector3 shootDir, BulletPool bulletPool)
    {
        //var bullet = bulletPool.Pull();
        //bullet.damage = stats.damage;
        //bullet.SetUp(bulletOriginPoint.position, Quaternion.LookRotation(shootDir, Vector3.up));
        for (int i = 0; i < stats.bulletsShotAtOnce; i++)
        {
            Debug.Log("X");
            var bullet = bulletPool.Pull();
            bullet.damage = stats.damage;
            bullet.SetUp(bulletOriginPoint.position, 
                         Quaternion.LookRotation(OffsetRandom(shootDir, stats.accuracyOffset), Vector3.up));
        }
    }

    public Vector3 OffsetRandom(Vector3 vec, float value)
    {
        return new Vector3(vec.x + Random.Range(-value, value),
                            vec.y,
                            vec.z + Random.Range(-value, value));
    }
}
