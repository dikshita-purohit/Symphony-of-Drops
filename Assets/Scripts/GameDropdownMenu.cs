using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameDropdownMenu : MonoBehaviour
{
    public TMP_Dropdown dropdown;

    void Start()
    {
        // Reset dropdown at start (no option selected)
        dropdown.value = 0;
        dropdown.onValueChanged.AddListener(OnOptionSelected);
    }

    void OnOptionSelected(int index)
    {
        string option = dropdown.options[index].text;

        if (option == "Home")
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu"); // replace with your home scene name
        }
        else if (option == "Restart")
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (option == "Pause")
        {
            if (Time.timeScale == 1f)
                Time.timeScale = 0f; // pause
            else
                Time.timeScale = 1f; // resume
        }

        // Reset dropdown back to default (so you can select again)
        dropdown.value = 0;
    }
}
