using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskScript : MonoBehaviour
{
    [SerializeField] private CameraController cameraControls;
    [SerializeField] private Transform target;
    [SerializeField] private CatFound cat;

    //All the UI being used
    public TextMeshProUGUI pressT;
    public GameObject task1;
    public GameObject task2;
    public GameObject task1b;
    //public GameObject task1c;

    //public bool playerInsideTrigger;

    //What is the task status?
    [HideInInspector] public bool task1Started;
    public bool task1Complete;
    public bool task2Complete;
    public bool catCollected;
    

    private void Start()
    {
        //Tasks set to not "completed" on start.
        task1Complete = false;
        task2Complete = false;
        cameraControls.GetComponent<CameraController>();
        catCollected = false;
    }

    private void Update()
    {
        //****ATTENTION****
        //THIS SHOULD PROBABLY BE IN A DATAMANAGER SCRIPT INSTEAD
        if (cat.catCollected == true)
        {
            task1Complete = true;
            task1Started = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.LookAt(target);
    }

    //Shows UI for different tasks
    public void TaskStart()
    {
      
        if (task1Complete != true && task1Started != true)
            {
                Debug.Log("Task1 Started");
                task1.gameObject.SetActive(true);
                cameraControls.enabled = false;
            }

        /*DRAFTING ANOTHER UI
         * if (task1Complete != true && task1Started == true)
        {
            Debug.Log("Task1 Complete");
            task1c.gameObject.SetActive(true);
            cameraControls.enabled = false;
        } */

        if (task1Complete == true)
            {
                task2.gameObject.SetActive(true);
                cameraControls.enabled = false;
            }
        
    }

    public void TaskExit()
    {
        Debug.Log("Task not undertaken");
        task1.gameObject.SetActive(false);
        pressT.gameObject.SetActive(false);
        //task2.gameObject.SetActive(false);
        cameraControls.enabled = true;
    }

 
    public void Task1()
    {
        task1.gameObject.SetActive(false);
        Debug.Log("Task 1 Started");
        task1b.gameObject.SetActive(true);
        
    }
    public void Task1Started()
    {
        cat.gameObject.SetActive(true);
        task1b.gameObject.SetActive(false);
        pressT.gameObject.SetActive(false);
        cameraControls.enabled = true;
        task1Started = true;

    }

    public void Task2()
    {
        task2.gameObject.SetActive(false);
        Debug.Log("Task 2 Started");
        cameraControls.enabled = true;
    }

}

