using UnityEngine;

public class RopeCutter : MonoBehaviour
{
    Vector2 worldMousePosition;

    public GameObject objectToIgnore;

    void Start()
    {
        if (objectToIgnore != null)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), objectToIgnore.GetComponent<Collider2D>());
        } 
        else
        {
            Debug.Log("Objeto ignorado não encontrado");
        }
    }

    void FixedUpdate()
    {
        worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = worldMousePosition;
    }
}
