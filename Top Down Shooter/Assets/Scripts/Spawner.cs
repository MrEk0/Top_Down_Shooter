using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject targetPrefab = null;
    [SerializeField] float spawnTime = 2f;
    [SerializeField] float offset = 1f;
    [SerializeField] float maxTargetNumber = 10f;

    float timeSinceLastSpawn = 0f;
    float minPosX;
    float maxPosX;
    float minPosY;
    float maxPosY;
    float radius;

    TargetManager gameManager;

    private void Awake()
    {
        radius = targetPrefab.GetComponent<CircleCollider2D>().radius;
        gameManager = FindObjectOfType<TargetManager>();
    }

    private void Start()
    {
        minPosX = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + offset;
        maxPosX = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - offset;
        minPosY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + offset;
        maxPosY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - offset;
    }

    private void Update()
    {
        if (timeSinceLastSpawn > spawnTime) 
        {
            timeSinceLastSpawn = 0f;
            Spawn();
        }
        timeSinceLastSpawn += Time.deltaTime;
    }

    private void Spawn()
    {
        float spawnPosX = Random.Range(minPosX, maxPosX);
        float spawnPosY = Random.Range(minPosY, maxPosY);
        Vector3 startPos = new Vector3(spawnPosX, spawnPosY, 0);

        if (Physics2D.CircleCast(startPos, radius, Vector2.zero))
        {
            timeSinceLastSpawn = spawnTime + 1;
            return;
        }

        if (gameManager.GetTargetNumber() < maxTargetNumber)
        {
            GameObject target = Instantiate(targetPrefab, startPos, Quaternion.identity, transform);
            gameManager.AddTarget(target);
        }
    }
}
