using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerShooting : MonoBehaviour
{
    public Transform cam;
    public Transform weaponHolder;
    public ObjectPool bulletPool;
    public Weapon[] weapons = new Weapon[6];

    public Weapon.WeaponType currentWeaponType;
    Weapon currentWeapon;
    float millisecondsBetweenShots;
    Animator animator;
    Stopwatch stopwatch;
    Rigidbody rgbody;

    int[] weaponsIDs = { 1, 4, 7, 2, 9, 8 };

    private void Start()
    {
        rgbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        stopwatch = new Stopwatch();
        stopwatch.Start();
        foreach (var weapon in weapons)
        {
            weapon.gameObject.SetActive(false);
        }

        SetWeapon(0);
    }

    public void SetWeapon(int i)
    {
        if (currentWeapon != null)
            currentWeapon.gameObject.SetActive(false);
        currentWeapon = weapons[i];
        currentWeapon.gameObject.SetActive(true);
        currentWeaponType = (Weapon.WeaponType)i;
        millisecondsBetweenShots = 60 * 1000 / currentWeapon.stats.rateOfFire;

        // Animation
        animator.SetInteger("WeaponType_int", weaponsIDs[(int)currentWeaponType]);
        animator.SetBool("FullAuto_b", true);

        currentWeapon.ResetAmmoInClip();
        AmmoUIPanel.instance.Refresh(currentWeapon);
    }

    public void HandleShooting()
    {
        float xFire = CrossPlatformInputManager.GetAxisRaw("HorizontalFire");
        float zFire = CrossPlatformInputManager.GetAxisRaw("VerticalFire");
        if (Mathf.Abs(xFire) != 0 || Mathf.Abs(zFire) != 0)
        {
            animator.SetInteger("WeaponType_int", weaponsIDs[(int)currentWeaponType]);
            animator.SetBool("Shoot_b", true);
            animator.SetBool("FullAuto_b", true);
            Vector3 shootDir = (new Vector3(xFire, 0f, zFire)).normalized;
            shootDir = cam.localToWorldMatrix * shootDir;
            shootDir = (new Vector3(shootDir.x, 0f, shootDir.z)).normalized;
            rgbody.MoveRotation(Quaternion.LookRotation(shootDir, Vector3.up));
            if (currentWeapon.AmmoLeftInClip > 0)
            {
                if (stopwatch.ElapsedMilliseconds >= millisecondsBetweenShots)
                {
                    currentWeapon.Shoot(shootDir, bulletPool);
                    stopwatch.Restart();
                }
            }
            else
            {
                SetWeapon(0);
            }

        }
        else
        {
            animator.SetBool("Shoot_b", false);
        }
    }
}
