using System.Collections;
using UnityEngine;

public class ExplodeOnTouch : MonoBehaviour
{
    public float explosionRadius = 5f;
    public float explosionForce = 700f;
    public float damage = 50f;
    public GameObject explosionEffectPrefab; // Reference to the explosion effect prefab
    [SerializeField]
    private FloatRange explosionDelay;
    private bool isExploded;
    private Health health;

    void Start()
    {
        if (TryGetComponent(out health))
        {
            health.OnDeath += OnDeath;
        }
    }

    void OnDestroy()
    {
        if (health != null)
        {
            health.OnDeath -= OnDeath;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isExploded && collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Explode());
        }
    }

    private void OnDeath()
    {
        StartCoroutine(Explode());
    }

    private IEnumerator Explode()
    {
        isExploded = true;
        yield return new WaitForSeconds(explosionDelay.GetRandom());

        // Instantiate explosion effect
        if (explosionEffectPrefab != null)
        {
            Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity);
        }

        // Get all colliders within the explosion radius
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Magnet") && collider.gameObject != gameObject)
            {
                // Apply damage to other magnets
                if (collider.TryGetComponent(out Health magnetHealth))
                {
                    magnetHealth.TakeDamage(damage);
                }

                // Apply explosion force to other magnets
                if (collider.TryGetComponent(out Rigidbody2D rb))
                {
                    Vector2 direction = collider.transform.position - transform.position;
                    rb.AddForce(direction.normalized * explosionForce);
                }
            }
        }

        // Destroy the explosive magnet
        Destroy(gameObject);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}