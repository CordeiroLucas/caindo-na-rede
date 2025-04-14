using System.Collections;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class BolhaContoller : MonoBehaviour
{
    private Rigidbody2D rb;
    public float gravityScaleValue = 0.1f;

    public GameObject ball;
    private Rigidbody2D ballRb;

    private Renderer objectRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ballRb = ball.GetComponent<Rigidbody2D>();

        objectRenderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Bola")
        {
            liftBubble();
        }
        if (other.name == "Cutter")
        {
            destroyBubble();
        }
    }

    private void destroyBubble()
    {
        Debug.Log("Destroy");
        ballRb.gravityScale = 0.6f;
        GetComponent<AudioSource>().Play();
        objectRenderer.enabled = false;
        Destroy(this);
    }

    private void liftBubble()
    {
        rb.gravityScale = -gravityScaleValue;
        
        ballRb.velocity = new Vector2(rb.velocity.x, 0);
        ballRb.transform.position = transform.position;
        ballRb.gravityScale = rb.gravityScale;
    }
}
