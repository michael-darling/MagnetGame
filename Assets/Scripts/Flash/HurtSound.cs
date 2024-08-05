using UnityEngine;
using UnityEngine.UI;

public class HurtSound : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private AudioSource sound;

    void OnEnable()
    {
        playerHealth.OnTookDamage += PlayHurtSound; // Subscribe to the event
    }

    void OnDisable()
    {
        playerHealth.OnTookDamage -= PlayHurtSound; // Unsubscribe from the event
    }

    void PlayHurtSound(Health.TookDamageEvent eventData)
    {
        if (!sound.isPlaying)
        {
            //sound.loop = true;
            sound.Play();
        }
    }

    //void Update()
    //{
    //    if (isFlashing)
    //    {
    //        if (hurtImage.color.a > 0f)
    //        {
    //            Color color = hurtImage.color;
    //            color.a -= fadeSpeed * Time.deltaTime;
    //            hurtImage.color = color;

    //            if (hurtImage.color.a <= 0f)
    //            {
    //                isFlashing = false;
    //            }
    //        }
    //    }
    //}
}