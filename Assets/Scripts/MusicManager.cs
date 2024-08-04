using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource normalMusic;

    [SerializeField]
    private AudioSource lowHealthMusic;

    [SerializeField]
    private float deathFadeDuration = 1;

    [SerializeField]
    private Health playerHealth;

    private bool isGameOver;

    private void OnEnable()
    {
        playerHealth.OnDeath += OnDeath;
    }

    private void OnDisable()
    {
        playerHealth.OnDeath -= OnDeath;
    }

    private void OnDeath()
    {
        isGameOver = true;
        _ = StartCoroutine(FadeOut(normalMusic, deathFadeDuration));
        _ = StartCoroutine(FadeOut(lowHealthMusic, deathFadeDuration));
    }

    private IEnumerator FadeOut(AudioSource audioSource, float fadeDuration)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeDuration;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume; // Reset volume to the start volume
    }

    private void Update()
    {
        if (!isGameOver)
        {
            lowHealthMusic.volume = 1 - (playerHealth.CurrentHealth / playerHealth.maxHealth);
        }
    }
}
