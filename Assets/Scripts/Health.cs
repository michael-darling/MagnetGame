using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    public Transform healthBarSprite;

    [SerializeField]
    private GameObject deathAnimationPrefab;
    public event Action OnDeath;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
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
            Die();
            currentHealth = 0f;
            OnDeath?.Invoke();
        }
        UpdateHealthBar();
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        UpdateHealthBar();
    }

    private void Die()
    {
        if (deathAnimationPrefab)
        {
            Instantiate(deathAnimationPrefab, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}