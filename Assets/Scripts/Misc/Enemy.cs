using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : ObjectPoolItem
{
    int maxHealth;
    public int health = 50;
    public float speed;
    public int damage;
    public Transform player;

    NavMeshAgent agent;
    Animator animator;
    float colorChangeTimeLeft;
    float colorChangeTime = 0.5f;
    Material material; 

    void Awake()
    {
        maxHealth = health;

        if (player == null)
            player = FindObjectOfType<PlayerMovement>().transform;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        animator = GetComponentInChildren<Animator>();
        material = GetComponentInChildren<SkinnedMeshRenderer>().material;
    }

    void Update()
    {
        agent.destination = player.position;

        if (colorChangeTimeLeft <= 0)
        {
            material.SetColor("_Color", Color.white);
        }
        else
        {
            colorChangeTimeLeft -= Time.deltaTime;
        }

    }

    public void ReceiveDamage(int damage)
    {
        Debug.Log("Received");

        if (colorChangeTimeLeft <= 0)
        {
            material.SetColor("_Color", Color.red);
        }
        health -= damage;
        if (health <= 0)
            Die();
        colorChangeTimeLeft = colorChangeTime;
    }

    void Die()
    {
        pool.Release(this);
        Disable();
    }

    public override void SetUp(Vector3 spawnPosition, Quaternion spawnRotation)
    {
        base.SetUp(spawnPosition, spawnRotation);
        health = maxHealth;
        colorChangeTimeLeft = 0;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var health = collision.gameObject.GetComponent<PlayerHealth>();
            health.ReceiveDamage(damage);
        }
    }


}
