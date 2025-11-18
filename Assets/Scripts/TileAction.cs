using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;   // needed for scene loading

public class TileAction : MonoBehaviour
{
    public SpriteRenderer color;
    public int scorevalue = 1;
    private ScoreScript scoreScript;

    // Shared across all drops
    private static int dropsMissed = 0;
    private const int maxMisses = 5;

    void Start()
    {
        scoreScript = FindFirstObjectByType<ScoreScript>();
    }

    void Update()
    {
        // Mouse click
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            DetectClick(Mouse.current.position.ReadValue());
        }

        // Touch click
        if (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            DetectClick(Touchscreen.current.primaryTouch.position.ReadValue());
        }
    }

    void DetectClick(Vector2 screenPosition)
    {
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(screenPosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            color.color = Color.yellow;

            if (scoreScript != null)
            {
                scoreScript.ScoreUpdate(scorevalue);
            }
            else
            {
                Debug.LogWarning("ScoreScript not found in scene!");
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("border"))
        {
            if (color.color == Color.yellow)
            {
                Debug.Log("fine (clicked drop reached border, no penalty)");
            }
            else
            {
                dropsMissed++;
                Debug.Log("Drop missed! Total misses = " + dropsMissed);

                if (dropsMissed >= maxMisses)
                {
                    //Debug.Log("Game Ended after 5 misses!");

                    // Save the current scene as the last scene before going to GameOver
                    string currentScene = SceneManager.GetActiveScene().name;
                    PlayerPrefs.SetString("LastScene", currentScene);
                    PlayerPrefs.Save();

                    // Load GameOver scene
                    SceneManager.LoadScene("GameOver");
                }
            }
        }
    }
}
