using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [SerializeField]
    private Health playerHealth;

    [SerializeField]
    private GameObject canvas;

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

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
