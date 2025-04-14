using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private PlayerNameManager playerName;
    private ScoreManager scoreManager;

    void Start()
    {
        playerName = gameObject.GetComponent<PlayerNameManager>();
        scoreManager = gameObject.GetComponent<ScoreManager>();
    }

    public void StartGame()
    {
        if(!string.IsNullOrEmpty(playerName.nameInputField.text.Trim())) {
            Debug.Log(PlayerPrefs.GetString("PlayerName"));
            NextLevel();
        } else {
            playerName.nameInputField.GetComponent<Animator>().SetTrigger("EmptyInput");
            // Debug.Log("Digite Um Nome");
        }
    }

    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings - 1) 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else {
            Debug.Log("Ultima Fase Alcançada!");
            LoadMainMenu();
        }
    }

    public void ReloadFase()
    {
        // Recarrega a fase atual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        scoreManager.SendScores();
        SceneManager.LoadScene(0);
    }
}
