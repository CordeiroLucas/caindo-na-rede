using Unity.VisualScripting;
using UnityEngine;

public class BolhaContoller : MonoBehaviour
{
    private AudioSource bubbleAudio;
    [SerializeField] float effectTime = 3f;

    void Start()
    {
        bubbleAudio = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            bubbleAudio.Play();
            Rigidbody2D rb = GameObject.Find("Bola").GetComponent<Rigidbody2D>();
            rb.velocity = Vector2.zero;
            rb.gravityScale = -0.5f;

            if (Time.time > effectTime)
            {
                rb.gravityScale = 1f;
            }
            Destroy(this.gameObject);
        }
    }
}
