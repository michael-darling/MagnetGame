using UnityEngine;

public class HideCursor : MonoBehaviour
{
    void Start()
    {
        // Hide the cursor
        Cursor.visible = false;

        // Lock the cursor to the center of the game window
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Toggle cursor visibility and lock state when the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = !Cursor.visible;

            if (Cursor.visible)
            {
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}