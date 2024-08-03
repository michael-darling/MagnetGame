using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float damageAmount = 10f; // Amount of damage the enemy deals per second

    void OnCollisionStay2D(Collision2D collision)
    {
        // Check if the object the enemy is colliding with is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount * Time.deltaTime);
            }
        }
    }
}