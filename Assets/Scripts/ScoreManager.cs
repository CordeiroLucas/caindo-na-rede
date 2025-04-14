using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ScoreManager : MonoBehaviour
{
    private string url = "https://67fc1f681f8b41c81685c884.mockapi.io/api/scores/users";
    private string top5_api = "?sortBy=score&order=desc";

    private int playerScore;
    private string jsonResponse = "";

    public TMP_Text textField;

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
                PlayerPrefs.DeleteAll();
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
            jsonResponse = request.downloadHandler.text;      
            
        }
        else {
            Debug.Log("Erro ao Obter o Ranking");
        }
    }

    public void showScore()
    {
        ScoreBoard myScoreBoard;
        if (jsonResponse != null || jsonResponse != " " || textField != null) {
            jsonResponse = "{ \"scoreBoard\":" + jsonResponse + "}";
            try {
                myScoreBoard = JsonUtility.FromJson<ScoreBoard>(jsonResponse);

                int maxIndex =  myScoreBoard.scoreBoard.Length;

                textField.text = "";
                for (int i = 0; i < 5 && i < maxIndex; i++)
                {
                    textField.text += i+1 + "º - " + myScoreBoard.scoreBoard[i].playerName + ": " + myScoreBoard.scoreBoard[i].score;
                    textField.text += "\n";
                } 
            } catch (System.Exception)
            {
                textField.text = "Tente Novamente!";
                Debug.Log("Tente Novamente!");
            }
        }
        else {
            Debug.Log("Banco de Dados Vazio");
        }
    }

    [System.Serializable]
    public class Score
    {
        public string playerName;
        public int score;
        public int id;
    }

    public class ScoreBoard
    {
        public Score[] scoreBoard;
    }

}
