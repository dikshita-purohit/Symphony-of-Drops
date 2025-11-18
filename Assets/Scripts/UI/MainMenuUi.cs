using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuUi : MonoBehaviour
{

    public void SceneLoader()
    {
        SceneManager.LoadScene("Options");
    }

}
