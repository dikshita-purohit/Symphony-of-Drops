using UnityEngine;

public class positionScript : MonoBehaviour
{
    public float width = 10f;
    public float height = 5f;


    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));
    }
}
