using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] GameObject bulletPrefab = null;
    [SerializeField] Transform projectileStartPos = null;

    Rigidbody2D rb;
    Camera mainCamera;

    Vector2 movement;
    Vector2 mousePos;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        mousePos=mainCamera.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    private void FixedUpdate()
    {
        //rb.MovePosition(rb.position + movement * speed*Time.fixedDeltaTime);
        rb.velocity = movement * speed;

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x)*Mathf.Rad2Deg-90f;
        rb.rotation = angle;
    }

    private void Fire()
    {
        Instantiate(bulletPrefab, projectileStartPos.position, projectileStartPos.rotation);
    }
}
