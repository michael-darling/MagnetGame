using UnityEngine;

public class ExplodeOnTouch : MonoBehaviour
{
    public float explosionRadius = 5f;
    public float explosionForce = 700f;
    public float damage = 50f;
    public GameObject explosionEffectPrefab; // Reference to the explosion effect prefab

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Explode();
        }
    }

    void Explode()
    {
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
                // Apply damage
                if (collider.TryGetComponent<Health>(out var magnetHealth))
                {
                    magnetHealth.TakeDamage(damage);
                }

                // Apply explosion force
                if (collider.TryGetComponent<Rigidbody2D>(out var rb))
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