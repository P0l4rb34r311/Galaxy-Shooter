using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
    [SerializeField]
    public Slider _ammo;

    public void SetMaxAmmo(int playerAmmo)
    {
        _ammo.maxValue = playerAmmo;
        _ammo.value = playerAmmo;
    }

    public void SetAmmo(int playerAmmo)
    {
        _ammo.value = playerAmmo;
    }
}
