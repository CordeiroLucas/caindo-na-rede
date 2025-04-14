using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    private string url = "https://67fc1f681f8b41c81685c884.mockapi.io/api/scores/users";
    private string top5_api = "?sortBy=score&order=desc";

    private int playerScore;

    void Start()
    {
        GetRankings();
    }

    public void SendScores()
    {
        StartCoroutine(SendRoutine());
    }

    IEnumerator SendRoutine()
    {
        string name = PlayerPrefs.GetString("PlayerName");
        
        getTotalScore();

        WWWForm form = new WWWForm();
        form.AddField("playerName", name);
        form.AddField("score", playerScore);

        // Envia para API

        using(UnityWebRequest request = UnityWebRequest.Post(url, form))
        {
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Pontuação salva com sucesso");
            }
            else 
            {
                Debug.Log("Erro ao salvar pontuação" + request.error);
            }
        }
    }

    public int getTotalScore()
    {
        int totalFases = SceneManager.sceneCountInBuildSettings;
        for (int i = 1; i < totalFases; i++)
        {
            playerScore += PlayerPrefs.GetInt(i.ToString());
        }
        return playerScore;
    }

    public void GetRankings()
    {
        StartCoroutine(GetRankingRoutine());
    }

    IEnumerator GetRankingRoutine()
    {
        UnityWebRequest request = UnityWebRequest.Get(url + top5_api);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string jsonResponse = request.downloadHandler.text;
            

            // Debug.Log(JsonUtility.FromJson<ArrayList>(jsonResponse));
            // Debug.Log("JSON Response: " + jsonResponse);
        }
        else {
            Debug.Log("Erro ao Obter o Ranking");
        }
    }
}
