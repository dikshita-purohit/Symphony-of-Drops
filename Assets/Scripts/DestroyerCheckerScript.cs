using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyerCheckerScript : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(col.gameObject);
    }


}
