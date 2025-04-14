using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int sceneScore = 0;
    private ScoreManager scoreManager;

    [SerializeField] GameObject cutter;

    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject winScreen;
    [SerializeField] GameObject backGroundSound;
    private AudioSource bgSound;

    [SerializeField] AudioClip gameOverAudio;
    [SerializeField] AudioClip winAudio;

    // Start is called before the first frame update
    void Start()
    {
        bgSound = backGroundSound.GetComponent<AudioSource>();
        scoreManager = gameObject.GetComponent<ScoreManager>();
        gameOverScreen.SetActive(false);
        winScreen.SetActive(false);
        Time.timeScale = 1;
        sceneScore = 0;

        scoreManager.GetRankings();
        scoreManager.showScore();
    }

    // Update is called once per frame
    void Update()
    {
        detectMouse();
    }

    // Mostra a bolinha quando pressionado o botao esquerdo do mouse / ou toque
    private void detectMouse()
    {
        if (Input.GetMouseButton(0) || Input.touchCount > 0)
            cutter.SetActive(true);
        else   
            cutter.SetActive(false);
    }

    public int getSceneScore()
    {
        return sceneScore;
    }

    public void addSceneScore(int points)
    {
        sceneScore += points;
    }

    public void winFunction()
    {
        Time.timeScale = 0;
        playAudio(winAudio);
        winScreen.SetActive(true);

        string SceneBuildNumber = SceneManager.GetActiveScene().buildIndex.ToString();

        PlayerPrefs.SetInt(SceneBuildNumber, sceneScore);
        PlayerPrefs.Save();

        sceneScore = 0;
    }

    public void gameOver()
    {   
        Time.timeScale = 0;
        playAudio(gameOverAudio);
        gameOverScreen.SetActive(true);
    }

    private void playAudio(AudioClip audio)
    {
        bgSound.clip = audio;
        bgSound.loop = false;
        bgSound.Play();
    }
}
