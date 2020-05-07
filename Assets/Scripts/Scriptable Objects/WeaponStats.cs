using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponStats", menuName = "ScriptableObjects/WeaponStats", order = 1)]
public class WeaponStats : ScriptableObject
{
    public string name = "";
    public int rateOfFire;
    public int clipCapacity;
    public int damage;
    public float accuracyOffset;
    public int bulletsShotAtOnce;

    public Vector3 rotationEulerAngles;
    public Vector3 positionOffset;
}
