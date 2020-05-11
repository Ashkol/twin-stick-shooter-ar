using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 20f;
    public Transform cam;

    Rigidbody rgbody;
    Animator animator;
    Stopwatch stopwatch;
    PlayerHealth health;
    PlayerShooting shooting;

    void Start()
    {
        rgbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        stopwatch = new Stopwatch();
        health = GetComponent<PlayerHealth>();
        shooting = GetComponent<PlayerShooting>();

        stopwatch.Start();

        animator.SetInteger("WeaponType_int", 1);
        animator.SetBool("Shoot_b", false);
        animator.SetBool("FullAuto_b", true);
    }

    void Update()
    {
        shooting.HandleShooting();
    }

    void FixedUpdate()
    {
        Move();
        rgbody.velocity = Vector3.zero;
        rgbody.angularVelocity = Vector3.zero;
    }

    private void Move()
    {
        float x = CrossPlatformInputManager.GetAxisRaw("Horizontal");
        float z = CrossPlatformInputManager.GetAxisRaw("Vertical");
        Vector3 moveDir = new Vector3(x, 0f, z);
        moveDir = cam.localToWorldMatrix * moveDir;
        moveDir = (new Vector3(moveDir.x, 0f, moveDir.z)).normalized;
        animator.SetFloat("Speed_f", moveDir.magnitude);
        if (moveDir != Vector3.zero)
        {
            rgbody.MovePosition(transform.position + moveDir * Time.fixedDeltaTime * speed);
            if (!animator.GetBool("Shoot_b"))
                rgbody.MoveRotation(Quaternion.LookRotation(moveDir, Vector3.up));
        }
    }
}
