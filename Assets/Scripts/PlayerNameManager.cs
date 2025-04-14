using TMPro;
using UnityEngine;

public class PlayerNameManager : MonoBehaviour
{
    public TMP_InputField nameInputField;

    public void SaveName()
    {
        string nome = nameInputField.text.Trim();

        if (!string.IsNullOrEmpty(nome))
        {
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetString("PlayerName", nome);
            PlayerPrefs.Save();
        }
    }
}
