using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] List<GameObject> bullets = null;
    [SerializeField] Transform firePoint = null;

    GameObject currentBullet;
    WeaponPanel weaponPanel;

    //float timeSinceLastShot = 0f;
    //float fireRate;

    private void Start()
    {
        currentBullet = bullets[0];
        weaponPanel = FindObjectOfType<WeaponPanel>();
        //fireRate = currentBullet.GetComponent<Bullet>().GetFireRate();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentBullet = bullets[0];
            weaponPanel.ChangeWeapon(0);
            //fireRate = currentBullet.GetComponent<Bullet>().GetFireRate();
        }

        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentBullet = bullets[1];
            weaponPanel.ChangeWeapon(1);
            //fireRate = currentBullet.GetComponent<Bullet>().GetFireRate();
        }

        if(Input.GetMouseButtonDown(0) /*&& timeSinceLastShot>fireRate*/)
        {
            Shot();
            //timeSinceLastShot = 0;
        }
        //timeSinceLastShot += Time.deltaTime;
    }

    private void Shot()
    {
        /*GameObject bullet=*/Instantiate(currentBullet, firePoint.position, firePoint.rotation);
        //bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * 10, ForceMode2D.Impulse);
    }
}
