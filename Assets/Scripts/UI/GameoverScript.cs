using UnityEngine;
using UnityEngine.SceneManagement; 

public class GameoverScript : MonoBehaviour
{
    public void Replay()
    {
        string lastScene = PlayerPrefs.GetString("LastScene", "GameScene");
        Debug.Log("Replaying scene: " + lastScene);

        SceneManager.LoadScene(lastScene);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        // Works inside Unity Editor
        UnityEditor.EditorApplication.isPlaying = false;
#else
       
        Application.Quit();
#endif

        Debug.Log("QuitGame: Application.Quit() called");
    }
}
