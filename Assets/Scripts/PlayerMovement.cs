using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("Bullets per minute")]
    public int rateOfFire = 120;
    public float speed = 20f;

    public Transform cam;
    public Transform weaponHolder;
    public BulletPool bulletPool;
    public Weapon[] weapons = new Weapon[6];

    public Weapon.WeaponType currentWeaponType;
    private Weapon currentWeapon;

    Rigidbody rgbody;
    Animator animator;
    Stopwatch stopwatch;
    float millisecondsBetweenShots;

    int[] weaponsIDs = { 1, 4, 7, 2, 9, 8 };

    void Start()
    {
        rgbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        stopwatch = new Stopwatch();

        stopwatch.Start();

        animator.SetInteger("WeaponType_int", 1);
        animator.SetBool("Shoot_b", false);
        animator.SetBool("FullAuto_b", true);


        foreach (var weapon in weapons)
        {
            weapon.gameObject.SetActive(false);
        }

        // Instantiate Weapon
        SetWeapon(0);
    }

    // Update is called once per frame
    void Update()
    {
        HandleShooting();
        //UnityEngine.Debug.Log(animator.GetCurrentAnimatorStateInfo.);
    }

    void FixedUpdate()
    {
        Move();
    }

    public void SetWeapon(int i)
    {
        if (currentWeapon != null)
            currentWeapon.gameObject.SetActive(false);
        currentWeapon = weapons[i];
        currentWeapon.gameObject.SetActive(true);
        currentWeaponType = (Weapon.WeaponType)i;
        millisecondsBetweenShots = 60 * 1000 / currentWeapon.stats.rateOfFire;
        animator.SetInteger("WeaponType_int", weaponsIDs[(int)currentWeaponType]);
        animator.SetBool("FullAuto_b", true);
        //stopwatch.Resstart();
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

    void SetAnimation()
    {

    }

    void HandleShooting()
    {
        float xFire = CrossPlatformInputManager.GetAxisRaw("HorizontalFire");
        float zFire = CrossPlatformInputManager.GetAxisRaw("VerticalFire");
        if (Mathf.Abs(xFire) != 0 || Mathf.Abs(zFire) != 0)
        {
            //animator.SetInteger("WeaponType_int", 1);
            animator.SetInteger("WeaponType_int", weaponsIDs[(int)currentWeaponType]);
            animator.SetBool("Shoot_b", true);
            animator.SetBool("FullAuto_b", true);
            Vector3 shootDir = (new Vector3(xFire, 0f, zFire)).normalized;
            shootDir = cam.localToWorldMatrix * shootDir;
            shootDir = (new Vector3(shootDir.x, 0f, shootDir.z)).normalized;
            rgbody.MoveRotation(Quaternion.LookRotation(shootDir, Vector3.up));
            if (stopwatch.ElapsedMilliseconds >= millisecondsBetweenShots)
            {
                currentWeapon.Shoot(shootDir, bulletPool);
                //bulletPool.Pull();
                stopwatch.Restart();
            }
        }
        else
        {
            animator.SetBool("Shoot_b", false);
            //animator.SetInteger("WeaponType_int", -1);
        }
    }


}
