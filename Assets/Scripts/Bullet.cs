using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : ObjectPoolItem
{
    public float speed = 10f;
    public int damage = 10;

    Rigidbody rgbody;
    TrailRenderer trail;


    void Awake()
    {
        rgbody = GetComponent<Rigidbody>();
        rgbody.velocity = transform.forward * speed;
        trail = GetComponentInChildren<TrailRenderer>();
    }

    public override void SetUp(Vector3 spawnPosition, Quaternion spawnRotation)
    {
        base.SetUp(spawnPosition, spawnRotation);
        rgbody.velocity = transform.forward * speed;;
        trail.Clear();
    }

    void OnTriggerEnter(Collider other)
    {
        Disable();
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy");
            var enemy = other.gameObject.GetComponent<Enemy>();
            enemy.ReceiveDamage(damage);
        }
    }
}
