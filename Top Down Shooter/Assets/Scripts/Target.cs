using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Target : MonoBehaviour
{
    [SerializeField] float awardForDestroying = 10f;

    public event Action<GameObject> OnRemoved;
    public event Action<float> OnDestroyed;

    private void OnDestroy()
    {
        OnRemoved(gameObject);
        OnDestroyed(awardForDestroying);
    }
}
