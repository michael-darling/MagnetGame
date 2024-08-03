using System.Collections;
using UnityEngine;

public class MagnetSpawner : MonoBehaviour
{
    public GameObject magnetPrefab; // The magnet prefab to spawn
    public float spawnInterval = 5f; // Time interval between spawns
    public float spawnRadius = 10f; // Radius within which to spawn magnets
    public bool randomizePolarity;

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
        // Random position within a circle of spawnRadius
        Vector2 spawnPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;

        // Instantiate the magnet
        GameObject newMagnet = Instantiate(magnetPrefab, spawnPosition, Quaternion.identity);

        // Optionally, configure the new magnet (e.g., random polarity)
        if (randomizePolarity)
        {
            Magnet magnetScript = newMagnet.GetComponent<Magnet>();
            magnetScript.isPositive = Random.value > 0.5f; // Randomly set polarity
        }
    }
}