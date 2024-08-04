using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource lowHealthMusic;

    [SerializeField]
    private Health playerHealth;

    private void Update()
    {
        lowHealthMusic.volume = 1 - (playerHealth.CurrentHealth / playerHealth.maxHealth);
    }
}
