using UnityEngine;
using UnityEngine.UI;

public class ScreenFlash : MonoBehaviour
{
    [SerializeField] private Image hurtImage; // Reference to the UI Image component
    public float fadeSpeed = 2f; // Speed of the fade effect
    private bool isFlashing = false; // Condition to check if the screen is flashing
    [SerializeField] private Health playerHealth;
    [SerializeField] private float maxAlpha = 0.3f;

    void OnEnable()
    {
        playerHealth.OnTookDamage += FlashScreen; // Subscribe to the event
    }

    void OnDisable()
    {
        playerHealth.OnTookDamage -= FlashScreen; // Unsubscribe from the event
    }

    void FlashScreen(Health.TookDamageEvent eventData)
    {
        isFlashing = true;
        Color color = hurtImage.color;
        color.a = maxAlpha; // Set alpha to fully opaque
        hurtImage.color = color;
    }

    void Update()
    {
        if (isFlashing)
        {
            if (hurtImage.color.a > 0f)
            {
                Color color = hurtImage.color;
                color.a -= fadeSpeed * Time.deltaTime;
                hurtImage.color = color;

                if (hurtImage.color.a <= 0f)
                {
                    isFlashing = false;
                }
            }
        }
    }
}