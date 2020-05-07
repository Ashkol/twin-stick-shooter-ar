using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollectable : MonoBehaviour, ICollectable
{
    public Weapon.WeaponType weapon;

    void Update()
    {
        Hover();
    }

    public void Hover()
    {
        transform.RotateAround(transform.position, Vector3.up, 1f);
    }

    public void PickUp()
    {
        FindObjectOfType<PlayerMovement>().SetWeapon((int)weapon);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PickUp();
        }
    }

}
