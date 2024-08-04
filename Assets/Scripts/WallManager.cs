using UnityEngine;

public class WallManager : MonoBehaviour
{
    public GameObject topWallPrefab;
    public GameObject bottomWallPrefab;
    public GameObject leftWallPrefab;
    public GameObject rightWallPrefab;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        PositionWalls();
    }

    void PositionWalls()
    {
        Vector2 screenBottomLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        Vector2 screenTopRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.nearClipPlane));

        // Calculate the size of the walls based on the screen size
        float wallThickness = 1f; // Adjust as needed
        float horizontalWallWidth = screenTopRight.x - screenBottomLeft.x + 2 * wallThickness;
        float verticalWallHeight = screenTopRight.y - screenBottomLeft.y + 2 * wallThickness;

        // Top wall
        GameObject topWall = Instantiate(topWallPrefab);
        topWall.transform.position = new Vector2(0, screenTopRight.y + wallThickness / 2);
        topWall.transform.localScale = new Vector2(horizontalWallWidth, wallThickness);

        // Bottom wall
        GameObject bottomWall = Instantiate(bottomWallPrefab);
        bottomWall.transform.position = new Vector2(0, screenBottomLeft.y - wallThickness / 2);
        bottomWall.transform.localScale = new Vector2(horizontalWallWidth, wallThickness);

        // Left wall
        GameObject leftWall = Instantiate(leftWallPrefab);
        leftWall.transform.position = new Vector2(screenBottomLeft.x - wallThickness / 2, 0);
        leftWall.transform.localScale = new Vector2(wallThickness, verticalWallHeight);

        // Right wall
        GameObject rightWall = Instantiate(rightWallPrefab);
        rightWall.transform.position = new Vector2(screenTopRight.x + wallThickness / 2, 0);
        rightWall.transform.localScale = new Vector2(wallThickness, verticalWallHeight);
    }
}