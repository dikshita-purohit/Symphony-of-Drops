using UnityEngine;
using TMPro;

public class lastScore : MonoBehaviour
{
    public TextMeshProUGUI mytext;

    void Start()
    {
        int scorePoints = PlayerPrefs.GetInt("LastScore", 0);
        mytext.text = scorePoints.ToString("0");

        // Debug log for Game Over screen
        //Debug.Log("Final collected score: " + scorePoints);
    }
}
