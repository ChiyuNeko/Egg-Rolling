using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDown : MonoBehaviour
{
    [Header("Prefab Settings")]
    public GameObject[] prefabs; // List of prefabs to spawn

    [Header("Spawn Area")]
    public float xMin = -26f; // Minimum X value
    public float xMax = -21f; // Maximum X value
    public float zMin = -39f; // Minimum Z value
    public float zMax = -21f; // Maximum Z value
    public float yPosition = 17f; // Fixed Y position (height)

    [Header("Spawn Settings")]
    public float spawnInterval = 1f; // Time between spawns

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnRandomPrefab();
            timer = 0f;
        }
    }

    void SpawnRandomPrefab()
    {
        // Check if there are prefabs to spawn
        if (prefabs.Length == 0) return;

        // Choose a random prefab
        GameObject prefabToSpawn = prefabs[Random.Range(0, prefabs.Length)];

        // Generate a random spawn position within the specified range
        float randomX = Random.Range(xMin, xMax);
        float randomZ = Random.Range(zMin, zMax);
        Vector3 spawnPosition = new Vector3(randomX, yPosition, randomZ);

        // Instantiate the prefab
        GameObject newObject = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

        if (!newObject.GetComponent<StopOnCollision>())
        {
            newObject.AddComponent<StopOnCollision>();
        }
    }
}
