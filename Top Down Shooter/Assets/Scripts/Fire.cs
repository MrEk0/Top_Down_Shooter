using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] GameObject buletPrefab = null;
    [SerializeField] Transform firePoint = null;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shot();
        }
    }

    private void Shot()
    {
        GameObject bullet=Instantiate(buletPrefab, firePoint.position, firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * 10, ForceMode2D.Impulse);
    }
}
