using System.Collections;
using UnityEngine;

public class MagnetSpawner : MonoBehaviour
{
    public GameObject[] magnetPrefabs; // The magnet prefab to spawn
    public float spawnInterval = 5f; // Time interval between spawns
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
            yield return new WaitForSeconds(spawnInterval);
        }
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

        GameObject randomPrefab = magnetPrefabs[Random.Range(0, magnetPrefabs.Length)];

        // Instantiate the magnet
        Instantiate(randomPrefab, spawnPosition, Quaternion.identity);
    }
}