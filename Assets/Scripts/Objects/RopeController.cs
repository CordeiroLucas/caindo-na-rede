using UnityEngine;

public class RopeController : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DestroyRope();
            Destroy(gameObject);
        }
    }

    void DestroyRope()
    {
        Transform parentTransform = transform.parent;
        if (parentTransform != null) 
        {
            int childCount = parentTransform.childCount;
            for (int i = 0; i < childCount; i++)
            {
                Transform child = parentTransform.GetChild(i);
                Destroy(child.gameObject);
            }
        }
        else {
            Debug.Log("GameObject Não Possui Objeto Pai!");
        }
    }
}
