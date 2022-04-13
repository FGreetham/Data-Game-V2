using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerNameScript : MonoBehaviour
{
    [SerializeField] private GameObject startButton;

    public GameObject inputField;

    public string inputText;
    // public string PlayerName; //Key for the player prefs. Surely this shouldn't be needed?

    private void Start()
    {
        // if(PlayerPrefs.HasKey(PlayerName))
        //Why does this not recognise Key 'PlayerName' from SetString method?

        if (PlayerPrefs.HasKey(PlayerName) == true)
        {
            PlayerPrefs.GetString(PlayerName);
            Debug.Log("Player name is" + PlayerName);
            //If I use variable above - it will come back with this HasKey debug.log
            //So it thinks something is set to the PlayerPrefs...
            //But it won't show the "PlayerName" text.
        }
        else
            Debug.Log("No player name");
    }

    //Attached to the button script and it can pull the string from the text input field.
    public void SaveName6()
    {
        string inputText = inputField.GetComponent<TMP_InputField>().text;
        Debug.Log(inputText);

        PlayerPrefs.SetString(PlayerName, inputText);
        //Have put this here as the SetString method below doesn't seem to work
        //Only works if I make a seperate PlayerName variable like above. 


        // SceneManager.LoadScene("Garden Scene");
    }

    public void SetString(string PlayerName, string inputText)
    {
        PlayerPrefs.SetString(PlayerName, inputText);
        //ATTENTION
        //Something here isn't working.. it doesn't pull to a GetString method (returns 'void')
        //and the Key 'PlayerName' is not recognised for HasKey either.
        //Also how do I know if it's connected to my local variable 'inputText' from the SaveName6 method
        //and it hasn't just created a new 'inputText' variable for itself?
    }


    //Only shows the Start button which calls the SaveName method when player begins typing
    public void ButtonShow()
    {
        startButton.SetActive(true);
    }


}
