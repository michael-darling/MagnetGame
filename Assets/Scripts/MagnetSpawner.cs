using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using Random = UnityEngine.Random;

public class MagnetSpawner : MonoBehaviour
{
    public GameObject[] magnetPrefabs; // Array of magnet prefabs to spawn
    public float[] magnetProbWeights;

    public float initialSpawnInterval = 5f; // Initial time interval between spawns
    public float minimumSpawnInterval = 1f; // Minimum time interval between spawns
    public float spawnIntervalDecreaseRate = 0.1f; // Rate at which the spawn interval decreases
    public float spawnRadius = 10f; // Radius within which to spawn magnets
    public Transform player; // Reference to the player
    public float minimumDistanceFromPlayer = 2f; // Minimum distance from player to spawn

    private float currentSpawnInterval;

    private void Start()
    {
        currentSpawnInterval = initialSpawnInterval;
        StartCoroutine(SpawnMagnets());
    }

    private IEnumerator SpawnMagnets()
    {
        while (true)
        {
            SpawnMagnet();
            yield return new WaitForSeconds(currentSpawnInterval);

            // Decrease the spawn interval over time
            currentSpawnInterval -= spawnIntervalDecreaseRate;
            if (currentSpawnInterval < minimumSpawnInterval)
            {
                currentSpawnInterval = minimumSpawnInterval;
            }
        }
    }

    private GameObject getMagnet()
    {
        float magnetWeightSum = magnetProbWeights.Sum();
        float threshold = Random.Range(0, magnetProbWeights.Sum());

        float sum = 0;
        for (int i = 0; i < magnetProbWeights.Length; i++)
        {
            sum += magnetProbWeights[i];
            if (threshold <= sum)
            {
                return magnetPrefabs[i];
            }
        }
        throw new Exception("Exception: Did not choose Magnet Prefab");
    }

    private void SpawnMagnet()
    {
        Vector2 spawnPosition;
        bool validPosition = false;

        do
        {
            // Random position within a circle of spawnRadius
            spawnPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;

            // Check if the position is far enough from the player
            if (Vector2.Distance(spawnPosition, player.position) >= minimumDistanceFromPlayer)
            {
                validPosition = true;
            }
        } while (!validPosition);

        // Select a random prefab from the array

        GameObject randomPrefab = getMagnet();

        // Instantiate the selected magnet
        Instantiate(randomPrefab, spawnPosition, Quaternion.identity);
    }
}