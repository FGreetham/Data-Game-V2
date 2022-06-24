using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishGame : MonoBehaviour    
{
    public GameObject sceneText;

    // Start is called before the first frame update
    void Start()
    {
            sceneText.GetComponent<TMP_Text>().text = "Thank you for playing " + PlayerPrefs.GetString("PlayerName") + ".\n" +
                "You can download your activity results below. \nSee you again soon!"; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
