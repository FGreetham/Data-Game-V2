using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class PlayerNameScript : MonoBehaviour
{
    [SerializeField] private GameObject startButton;

    public GameObject inputField;
    public string inputText;

    private void Start()
    {
        //Pulls the PlayerPrefs/PlayerName that was previously entered and puts it in the InputField
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            Debug.Log("Player name is " + PlayerPrefs.GetString("PlayerName"));
            
            inputField.GetComponent<TMP_InputField>().text = PlayerPrefs.GetString("PlayerName");
        }
        else
            Debug.Log("No player name");
    }

    //Attached to the button script and it can pull the string from the text input field.
    public void SaveName6()
    {
        string inputText = inputField.GetComponent<TMP_InputField>().text;

        //This SetString and GetString is working in the console
        PlayerPrefs.SetString("PlayerName", inputText);
        Debug.Log("GetString is " + PlayerPrefs.GetString("PlayerName"));

        SceneManager.LoadScene("Garden Scene");
    }

    //Only shows the Start button which calls the SaveName method when player begins typing
    public void ButtonShow()
    {
        startButton.SetActive(true);
    }
}
