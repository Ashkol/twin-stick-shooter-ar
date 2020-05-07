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

    public override void Disable()
    {
        gameObject.SetActive(false);
    }

    public override void Enable()
    {
        gameObject.SetActive(true);
    }

    public override void SetUp(Vector3 spawnPosition, Quaternion spawnRotation)
    {
        Debug.Log($"Spawn position: {spawnPosition}") ;
        transform.position = spawnPosition;
        transform.rotation = spawnRotation;
        rgbody.velocity = transform.forward * speed;
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
