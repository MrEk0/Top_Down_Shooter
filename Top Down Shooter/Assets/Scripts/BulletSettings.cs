using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Bullet", menuName ="Bullet")]
public class BulletSettings : ScriptableObject
{
    public float speed;
    public float fireRate;

    public Sprite sprite;

    //public float GetSpeed()
    //{
    //    return speed;
    //}

    //public float GetFireRate()
    //{
    //    return fireRate;
    //}

    //public Sprite GetSprite()
    //{
    //    return sprite;
    //}
}
