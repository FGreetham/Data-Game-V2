using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskScript : MonoBehaviour
{
    public Transform target;
    public TextMeshProUGUI pressT;
    
    private bool playerInsideTrigger;

    private void OnTriggerEnter(Collider other)
    {
        playerInsideTrigger = true;

        transform.LookAt(target);
        pressT.gameObject.SetActive(true);
        Debug.Log("In trigger zone");

        //I understand the Input.GetKey needs to be in an update as it doesn't work otherwise
        //but what if I only want it working whilst in Trigger zone,
        //rather than update method checking if character is in the trigger zone every frame?
        InvokeRepeating("Task", 0, 0.02f); 

    }

    public void Task()
    {
        if (playerInsideTrigger == true && Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("T pressed");
            return;
        }

        //Notes below
    }

    private void OnTriggerExit(Collider other)
    {
        pressT.gameObject.SetActive(false);
        playerInsideTrigger = false;
    }
}

//NOTES
//WaitForSeconds... once the player has click the button, they are still in triggerzone
//Need to implement coroutine to give the player time before UI displays again.. or 
//Make it so they need to exit trigger before entering again?