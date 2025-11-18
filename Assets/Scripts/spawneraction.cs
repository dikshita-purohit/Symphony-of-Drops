using UnityEngine;
using UnityEngine.SceneManagement;  // for scene loading

public class spawneraction : MonoBehaviour
{
    public float width = 10f;
    public float height = 5f;
    public GameObject RainTile;

    public float delay = 0.5f;
    public float min = .2f;
    public float max = 7f;

    private ScoreScript scoreScript;
    private float difficultyFactor = 1f;

    void Start()
    {
        scoreScript = FindAnyObjectByType<ScoreScript>();
        spawnUntill();
    }

    void Update()
    {
        if (checkforEmpty())
        {
            spawnUntill();
        }

        // Dynamically update difficulty based on score
        UpdateDifficulty();

        // Win condition
        if (scoreScript != null && scoreScript.scorePoints >= 50)
        {
            PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("WinScene");
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
    }

    void spawnUntill()
    {
        Transform position = freePosition();
        float random = Random.Range(min, max);
        Vector3 offset = new Vector3(0, random, 0);
        if (position)
        {
            GameObject rainDrop = Instantiate(RainTile, position.transform.position + offset, Quaternion.identity);
            rainDrop.transform.parent = position;
        }
        if (freePosition())
        {
            Invoke("spawnUntill", delay / difficultyFactor); // apply difficulty here
        }
    }

    bool checkforEmpty()
    {
        foreach (Transform child in transform)
        {
            if (child.childCount > 0)
            {
                return false;
            }
        }
        return true;
    }

    Transform freePosition()
    {
        foreach (Transform child in transform)
        {
            if (child.childCount == 0)
            {
                return child;
            }
        }
        return null;
    }

    void UpdateDifficulty()
    {
        if (scoreScript == null) return;

        int score = scoreScript.scorePoints;

        // First 10 drops = "medium"
        if (score < 10)
        {
            difficultyFactor = 0.8f;
        }
        // 10-25 drops = increase speed (skilled)
        else if (score >= 10 && score < 25)
        {
            difficultyFactor = 1.2f;
        }
        // 25-40 drops = expert level
        else if (score >= 25 && score < 40)
        {
            difficultyFactor = 1.8f;
        }
        // 80+ drops = max challenge
        else if (score >= 40)
        {
            difficultyFactor = 2.3f;
        }
    }
}
