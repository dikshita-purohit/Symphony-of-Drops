using UnityEngine;
using UnityEngine.SceneManagement;

public class WinSceneScript : MonoBehaviour
{
    public void Replay()
    {
        string lastScene = PlayerPrefs.GetString("LastScene", "GameScene");
        Debug.Log("Replaying scene: " + lastScene);
        StartCoroutine(ReloadScene(lastScene));
    }

    private System.Collections.IEnumerator ReloadScene(string sceneName)
    {
        yield return new WaitForSeconds(0.1f); // short delay so the log appears
        SceneManager.LoadScene(sceneName);
    }


    // Go to main menu
    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }

    // Quit the game
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        Debug.Log("QuitGame: Application.Quit() called");
    }
}
