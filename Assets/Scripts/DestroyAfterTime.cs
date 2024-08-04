using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float lifetime = 5f; // Time in seconds before the GameObject is destroyed

    void Start()
    {
        // Schedule the destruction of the GameObject
        Destroy(gameObject, lifetime);
    }
}