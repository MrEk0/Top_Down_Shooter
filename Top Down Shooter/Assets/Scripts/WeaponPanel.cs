using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPanel : MonoBehaviour
{
    [SerializeField] float alphaIndex = 100f;
    [SerializeField] List<Image> weapons = null;

    private Color pressedColor;
    private Color defaultColor;

    Image activeWeapon;

    private void Awake()
    {
        pressedColor = new Color(1, 1, 1, alphaIndex / 255);
        defaultColor = new Color(1, 1, 1, 1);
    }

    private void Start()
    {
        weapons[0].color = pressedColor;
        activeWeapon = weapons[0];
    }

    public void ChangeWeapon(int weaponIndex)
    {
        if (activeWeapon != weapons[weaponIndex])
        {
            weapons[weaponIndex].color = pressedColor;
            activeWeapon.color = defaultColor;

            activeWeapon = weapons[weaponIndex];
        }
    }
}
