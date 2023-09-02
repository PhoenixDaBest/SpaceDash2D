using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deployAsteroids : MonoBehaviour
{
    public GameObject objectToSpawn; // The object you want to spawn
    public Vector3 spawnAreaSize = new Vector3(10f, 0f, 10f); // The size of the spawn area
    public int numberOfObjectsToSpawn = 10; // Number of objects to spawn
    public float spawnInterval = 1f; // Time interval between spawns

    private void Start()
    {
        // Start spawning objects with a delay (if desired)
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }
    private void SpawnObject()
    {
        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            // Calculate a random position within the spawn area
            Vector3 spawnPosition = new Vector3(
                Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f),
                transform.position.y, // Keep the same Y position as the spawner
                Random.Range(-spawnAreaSize.z / 2f, spawnAreaSize.z / 2f)
            );

            // Instantiate the object at the random position
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}