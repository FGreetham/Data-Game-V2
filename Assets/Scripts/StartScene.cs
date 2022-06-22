using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartScene : MonoBehaviour      
{
    //Variables
    public GameObject sceneText;


    void Start()
    {
        sceneText.GetComponent<TMP_Text>().text = "Hi " + PlayerPrefs.GetString("PlayerName") + ", I need your help. I left my shed unlocked and there's a storm on the way. \n"  +
            "Could you check it for me? It's the one straight ahead as you go into the garden. \nThe password is 1111.";

    }



    public void SceneStart()
    {
        SceneManager.LoadScene("Garden Scene");
    }
}
