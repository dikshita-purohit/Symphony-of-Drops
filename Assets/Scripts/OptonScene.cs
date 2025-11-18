using UnityEngine;
using UnityEngine.SceneManagement;

public class OptonScene : MonoBehaviour
{

    public void girlGameScene()
    {
        SceneManager.LoadScene("GameSceneGirl");
    }

    public void boyGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
