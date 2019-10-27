using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Bullet", menuName ="Bullet")]
public class BulletSettings : ScriptableObject
{
    public float speed;

    public Sprite sprite;
}
