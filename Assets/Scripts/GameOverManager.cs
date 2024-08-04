using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    private Health playerHealth;

    [SerializeField]
    private GameObject canvas;

    private void OnEnable()
    {
        if (playerHealth)
        {
            playerHealth.OnDeath += OnPlayerDied;
        }
    }

    private void OnDisable()
    {
        if (playerHealth)
        {
            playerHealth.OnDeath -= OnPlayerDied;
        }
    }

    private void OnPlayerDied()
    {
        canvas.SetActive(true);
    }
}
