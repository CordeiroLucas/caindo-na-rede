using UnityEngine;

public class RopeCutter : MonoBehaviour
{
    Vector2 worldMousePosition;

    void Update()
    {
        worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = worldMousePosition;
    }
}
