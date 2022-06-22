using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskScript : MonoBehaviour
{
    //References
    [SerializeField] private DataManagerScript dataScript;
    [SerializeField] private CameraController cameraControls;
    [SerializeField] private CatFound cat;

    //Variables
    public GameObject[] npc1Tasks;
    public int taskIndex;
    [SerializeField] private Transform target;
    
    //public GameObject this[int taskIndex] => npc1Tasks[taskIndex];
    //public int dataScript.taskCollectables[taskIndex];


    //All the UI being used
    public TextMeshProUGUI pressT;
    public GameObject task1;
    public GameObject task1b;
    //public GameObject task2;
    //public GameObject task1c;

  
    //What is the task status?
    [HideInInspector] public bool task1Started;
    //private bool task2Complete;
    //private bool catCollected;
   // public bool taskRunning;
    public int clickedNo;

    private void Start()
    {
        cameraControls.GetComponent<CameraController>();
    }

    private void OnTriggerStay(Collider other)
    {
       // transform.LookAt(target);
        FaceDirecton(target.position);
      
    }
    void FaceDirecton(Vector3 target)
    {
        Vector3 direction = (target - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

        // transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime *2f);
    }


    private void Update()
    {
      
    }
    //Shows UI for different tasks
    public void TaskStart()
    {
        Debug.Log(npc1Tasks[taskIndex]);

        if (dataScript.taskRunning == true)
            return;
        //Put a "Come back when you're done" message...
        //otherwise nothing will happen when pressing T

        if (dataScript.taskRunning == false)
        {
            taskIndex++;
            cameraControls.enabled = false;
            npc1Tasks[taskIndex].SetActive(true);
            Debug.Log("Task Started");


        }
      
      /*  if (task1Complete != true && task1Started != true)
            {
                Debug.Log("Task1 Started");
                task1.gameObject.SetActive(true);
                
            }*/

        /*DRAFTING ANOTHER UI
         * if (task1Complete != true && task1Started == true)
        {
            Debug.Log("Task1 Complete");
            task1c.gameObject.SetActive(true);
            cameraControls.enabled = false;
        } 

        if (task1Complete == true)
            {
                task2.gameObject.SetActive(true);
                cameraControls.enabled = false;
            }*/
    }

    public void TaskExit()
    {
        npc1Tasks[taskIndex].SetActive(false);
        
        pressT.gameObject.SetActive(false);
      
        cameraControls.enabled = true;

        // Debug.Log("Task not undertaken");
        // task1.gameObject.SetActive(false);  
        //task2.gameObject.SetActive(false);
    }

    public void ClickedNo()
    {
        //Tracking if the player clicks no on a task
        clickedNo++;
        Debug.Log("Rejected tasks " + clickedNo);
        Invoke("TaskExit", 0);
    }

 
    //Can I delete? Or is this Task 1 method i need to keep?
    public void Task1()
    {
        task1.gameObject.SetActive(false);
        Debug.Log("Task 1 Started");
        task1b.gameObject.SetActive(true);
        
    }


    public void Task1Started()  //This will be on the "Ok" button click on Task1b. Rename Task1b 
    {
        dataScript.taskRunning = true;
        cat.gameObject.SetActive(true);
        task1b.gameObject.SetActive(false);
        Invoke("TaskExit", 0);
       // task1Started = true;
       
    }

   /* public void Task2()
    {
        task2.gameObject.SetActive(false);
        Debug.Log("Task 2 Started");
        cameraControls.enabled = true;
    } */

}

