using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoUIPanel : MonoBehaviour
{
    public static AmmoUIPanel instance;
    TextMeshProUGUI text;

    void Awake()
    {
        instance = this;
        text = GetComponent<TextMeshProUGUI>();
    }

    public void Refresh(Weapon weapon)
    {
        text.text = $"{weapon.AmmoLeftInClip}/{weapon.stats.clipCapacity}";
    }
}
