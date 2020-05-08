using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCrate : ObjectPoolItem
{
    public WeaponCollectable[] weaponPickUps = new WeaponCollectable[5];

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DamageSource"))
        {
            SpawnRandomWeapon();
            
            if (pool != null)
            {
                Disable();
                pool.Release(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    void SpawnRandomWeapon()
    {
        var weapon = Instantiate(weaponPickUps[Random.Range(0, weaponPickUps.Length)]);
        weapon.transform.position = transform.position;
    }


}
