using UnityEngine;
using System;
using System.Collections;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    public Transform healthBarSprite;

    [SerializeField]
    private GameObject deathAnimationPrefab;

    [SerializeField]
    private bool autoDestroyOnDeath = true;

    [SerializeField]
    private int scoreValue = 1;
    public float regenerationRate = 1f; // Time in seconds between each regeneration tick
    public float regenerationAmount = 5f; // Amount of health to regenerate each tick

    public event Action OnDeath;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
        StartCoroutine(RegenerateHealth()); // Start the regeneration coroutine
    }

    void UpdateHealthBar()
    {
        if (!healthBarSprite)
        {
            return;
        }
        healthBarSprite.localScale = Vector3.one * currentHealth / maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0f)
        {
            currentHealth = 0f;
            OnDeath?.Invoke();
            Die();
        }
        UpdateHealthBar();
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void Die()
    {
        ScoreManager.Instance.AddPoints(scoreValue);
        if (deathAnimationPrefab)
        {
            Instantiate(deathAnimationPrefab, transform.position, transform.rotation);
        }
        if (autoDestroyOnDeath)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator RegenerateHealth()
    {
        while (true)
        {
            yield return new WaitForSeconds(regenerationRate);
            if (currentHealth < maxHealth)
            {
                Heal(regenerationAmount);
            }
        }
    }
}