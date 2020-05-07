using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int health = 50;
    public float speed;
    public int damage;
    public Transform player;

    NavMeshAgent agent;
    Animator animator;
    float colorChangeTimeLeft;
    float colorChangeTime = 0.5f;
    Material material; 

    void Start()
    {
        if (player == null)
            player = FindObjectOfType<PlayerMovement>().transform;
        agent = GetComponent<NavMeshAgent>();
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
        Destroy(gameObject);
    }
}
