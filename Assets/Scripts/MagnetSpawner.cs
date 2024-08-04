using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class MagnetSpawner : MonoBehaviour
{
    public GameObject[] magnetPrefabs; // Array of magnet prefabs to spawn
    public float[] magnetProbWeights;

    [SerializeField]
    private float spawnRate = 1;
    public float SpawnRate
    {
        get => spawnRate;
        set => spawnRate = value;
    }

    public float spawnRadius = 10f; // Radius within which to spawn magnets
    public Transform player; // Reference to the player
    public float minimumDistanceFromPlayer = 2f; // Minimum distance from player to spawn

    private void Start()
    {
        StartCoroutine(SpawnMagnets());
    }

    private IEnumerator SpawnMagnets()
    {
        while (true)
        {
            SpawnMagnet();
            yield return new WaitForSeconds(1 / SpawnRate);
        }
    }

    private GameObject getMagnet()
    {
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
            if (player == null || Vector2.Distance(spawnPosition, player.position) >= minimumDistanceFromPlayer)
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