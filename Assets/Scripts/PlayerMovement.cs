using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of the player's movement

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input from WASD keys
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * moveSpeed;
    }

    void FixedUpdate()
    {
        // Move the player's magnet
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}