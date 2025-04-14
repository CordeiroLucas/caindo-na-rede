using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BallController : MonoBehaviour
{
    Collider2D myCollider;
    GameManager gameManager;
    [SerializeField] float bubbleEffectTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        myCollider.enabled = true;
    }

    void FixedUpdate()
    {
        outOfBounds();
    }

    private void outOfBounds()
    {
        if (transform.position.y < -15)
        {
            gameManager.gameOver();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {   
        // Acertou o Gol
        if (collision.gameObject.CompareTag("Goal"))
        {
            myCollider.enabled = false;
            Destroy(gameObject);
            gameManager.winFunction();
        }

        else if (collision.gameObject.CompareTag("Ground"))
        {
            myCollider.enabled = false;
            Destroy(gameObject);
            Time.timeScale = 0;
            gameManager.gameOver();
        }
    }
}
