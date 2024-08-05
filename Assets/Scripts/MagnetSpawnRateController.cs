using System.Collections;
using UnityEngine;

public class MagnetSpawnRateController : MonoBehaviour
{
    [SerializeField]
    private MagnetSpawner spawner;

    [SerializeField]
    private float timePerRateIncrease;

    [SerializeField]
    private float increaseAmount;

    private void OnEnable()
    {
        StartCoroutine(IncreaseSpawnRate());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator IncreaseSpawnRate()
    {
        while (true)
        {
            yield return new WaitForSeconds(timePerRateIncrease);
            spawner.SpawnRate += increaseAmount;
        }
    }
}
