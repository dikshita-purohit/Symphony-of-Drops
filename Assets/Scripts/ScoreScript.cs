using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI mytext;
    public int scorePoints;

    void Start()
    {
        // Reset score when starting a new game
        scorePoints = 0;
        mytext.text = scorePoints.ToString("0");

        PlayerPrefs.SetInt("LastScore", scorePoints);
        PlayerPrefs.Save();

     //   Debug.Log("New game started, score reset to 0");
    }

    public void ScoreUpdate(int score)
    {
        scorePoints += score;
        mytext.text = scorePoints.ToString("0");

        //Debug.Log("Collected so far: " + scorePoints);

        PlayerPrefs.SetInt("LastScore", scorePoints);
        PlayerPrefs.Save();
    }
}
