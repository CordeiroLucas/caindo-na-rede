using UnityEngine;

public class StarController : MonoBehaviour
{
    [SerializeField] GameObject destination;


    private AudioSource audioSource;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        audioSource = GetComponent<AudioSource>();
    }

    // 

    void OnTriggerEnter2D(Collider2D other)
    {
        // Checa Contato com A Bola
        if (other.gameObject.CompareTag("Ball")){
            gameObject.GetComponent<Collider2D>().enabled = false;
            
            audioSource.Play();
            MoveToPosition(destination);
            gameManager.addSceneScore(1);
            // Debug.Log(gameManager.getSceneScore());
        }
    }

    void MoveToPosition(GameObject gameObject)
    {
        Vector2 position = gameObject.transform.position;
        transform.position = position;
        transform.localScale = gameObject.transform.localScale;
    }
}
