using UnityEngine;

public class Magnet : MonoBehaviour
{
    public float strength = 10f;
    public bool isPositive = true;
    public float distancePower = 2;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Magnet[] magnets = FindObjectsOfType<Magnet>();
        foreach (Magnet magnet in magnets)
        {
            if (magnet != this)
            {
                ApplyForce(magnet);
            }
        }
    }

    void ApplyForce(Magnet otherMagnet)
    {
        Vector2 direction = otherMagnet.transform.position - transform.position;
        float distance = direction.magnitude;
        if (distance == 0f) return;

        float forceMagnitude = strength * otherMagnet.strength / Mathf.Pow(distance, distancePower);
        if (isPositive == otherMagnet.isPositive)
        {
            forceMagnitude = -forceMagnitude; // Repel if both have the same polarity
        }
        else
        {
            forceMagnitude = Mathf.Abs(forceMagnitude); // Attract if different polarities
        }

        Vector2 force = direction.normalized * forceMagnitude;
        rb.AddForce(force);
    }
}