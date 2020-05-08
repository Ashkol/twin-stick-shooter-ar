using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponStats stats;
    public GameObject weaponModel;
    public Transform bulletOriginPoint;

    public enum WeaponType
    {
        Pistol,
        Shotgun,
        SMG,
        AutomaticRifle,
        Minigun,
        RPG
    }

    int ammoLeftInClip;
    public int AmmoLeftInClip
    {
        get { return ammoLeftInClip; }
        private set { ammoLeftInClip = value; }
    }

    void Start()
    {
        ammoLeftInClip = stats.clipCapacity;
        transform.localPosition = stats.positionOffset;
        transform.localRotation = Quaternion.Euler(stats.rotationEulerAngles);
        //bulletPool = FindObjectOfType<BulletPool>();
    }

    public void Shoot(Vector3 shootDir, BulletPool bulletPool)
    {
        for (int i = 0; i < stats.bulletsShotAtOnce; i++)
        {
            try
            {
                var bullet = bulletPool.Acquire() as Bullet;
                bullet.damage = stats.damage;
                bullet.SetUp(bulletOriginPoint.position, Quaternion.LookRotation(OffsetRandom(shootDir, stats.accuracyOffset), Vector3.up));
                ammoLeftInClip -= 1;
                AmmoUIPanel.instance.Refresh(this);
            }
            catch (System.Exception ex)
            {

            }
        }
    }

    public Vector3 OffsetRandom(Vector3 vec, float value)
    {
        return new Vector3(vec.x + Random.Range(-value, value),
                            vec.y,
                            vec.z + Random.Range(-value, value));
    }

    public void ResetAmmoInClip()
    {
        AmmoLeftInClip = stats.clipCapacity;
    }
}
