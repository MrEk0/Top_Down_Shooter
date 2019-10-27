using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bullet : MonoBehaviour
{
    [SerializeField] GameObject explosionPrefab = null;
    [SerializeField] BulletSettings bullet;

    Rigidbody2D rd;
    float speed;

    private void Awake()
    {
        rd = GetComponent<Rigidbody2D>();
        GetComponent<SpriteRenderer>().sprite = bullet.sprite;
        speed = bullet.speed;
    }

    private void Start()
    {
        rd.AddForce(transform.up*speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject effect = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(effect, 2);

        if (collision.CompareTag("Target"))
        {
            GameObject target = collision.gameObject;
            Destroy(target);
        }

        Destroy(gameObject);
    }
}
