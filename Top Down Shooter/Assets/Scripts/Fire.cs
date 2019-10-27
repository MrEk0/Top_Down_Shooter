using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] List<GameObject> bullets = null;
    [SerializeField] Transform firePoint = null;
    [SerializeField] float defaultFireRate=1f;
    [SerializeField] float additionalFireDelay = 1f;

    GameObject currentBullet;
    WeaponPanel weaponPanel;

    float timeSinceLastShot = 10f;
    float fireRate;

    public event Action<float> OnShooted;

    private void Awake()
    {
        currentBullet = bullets[0];
        weaponPanel = FindObjectOfType<WeaponPanel>();
        fireRate = defaultFireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentBullet = bullets[0];
            weaponPanel.ChangeWeapon(0);
            fireRate = defaultFireRate;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentBullet = bullets[1];
            weaponPanel.ChangeWeapon(1);
            fireRate = defaultFireRate + additionalFireDelay;
        }

        if (Input.GetMouseButtonDown(0) && timeSinceLastShot>fireRate)
        {
            Shot();
            timeSinceLastShot = 0;
        }
        timeSinceLastShot += Time.deltaTime;
    }

    private void Shot()
    {
        Instantiate(currentBullet, firePoint.position, firePoint.rotation);
        OnShooted(fireRate);
    }
}
