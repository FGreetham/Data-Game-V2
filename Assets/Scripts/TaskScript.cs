using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskScript : MonoBehaviour
{
    [Header("Script References")]
    [SerializeField] private DataManagerScript dataScript;
    [SerializeField] private CameraController cameraControls;
    [SerializeField] private CharacterController controller;
    [SerializeField] private CatFound cat;
    [SerializeField] private Vegetables vegScript;
    [SerializeField] private DoorLock doorScript;
    [SerializeField] private Transform target;

    [Header("Task Index")]
    public GameObject[] npc1Tasks;
    public int taskIndex;
    public int clickedNo;
    public bool[] taskActive = new bool[3];
    public bool[] taskComplete = new bool[3];
    public bool allTasksComplete;

    [Header("GUI Elements")]
    public TextMeshProUGUI pressT;
    public GameObject task1;
    public GameObject task1b;
    public GameObject task2b;
    public GameObject comeBack;
    public GameObject successMsg;
    public GameObject allTasksMsg;

    private void Start()
    {
        cameraControls.GetComponent<CameraController>();
        allTasksComplete = false;
    }

    private void OnTriggerStay(Collider other)
    {
        FaceDirecton(target.position);
    }
    void FaceDirecton(Vector3 target)
    {
        Vector3 direction = (target - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 4f);
    }


    //Shows UI for different tasks
    public void TaskStart()
    {
        pressT.gameObject.SetActive(false);
      
        /*If task is active, "Come back when you're done" message appears.
         * If task completed, success message appears and data is added. */
        if (taskActive[taskIndex] == true)
        {
            if (taskIndex == 1)
            {
                if (cat.catCollected == true)
                {
                    StartCoroutine("SuccessMessage");
                }
                else
                    StartCoroutine("ComeBack");
            }
            if (taskIndex == 2)
            {
                if (vegScript.tomatoCount >= 5)
                {
                    StartCoroutine("SuccessMessage");
                                    }
                else
                    StartCoroutine("ComeBack");
            }

        }

        //If no task actively running, moves through array to next task.
        if (taskActive[taskIndex] == false)
        {
            for (int i = 0; i < taskComplete.Length; i++)
            {
                if (taskComplete[taskIndex++] == true)
                {
                    taskIndex += 2;
                    Debug.Log("Is this working?");
                    break;
                }
                else if (taskComplete[i] == false)
                {
                    cameraControls.enabled = false;
                    controller.enabled = false;
                    MoveThroughTasks();
                    break;
                }

                else
                    allTasksComplete = true;

            }

            if(allTasksComplete == true)
            {
                StartCoroutine("CompletedAll");
            }

        /*    //How do I check 'if ALL indexed tasks are completed?'
            if (taskComplete[1] == true && taskComplete[2] == true)     
           {
                StartCoroutine("CompletedAll");   
            }
            //How do I check which taskIndex is complete... if so, need to skip it.
            else
            {
                cameraControls.enabled = false;
                controller.enabled = false;

                Invoke("MoveThroughTasks", 0);
            } */

        }   
    }

    public void MoveThroughTasks()
    {
        //How do I check which taskIndex is complete... if so, need to skip it.
        taskIndex = (taskIndex++) % npc1Tasks.Length;

        if (npc1Tasks.Length-1 == taskIndex)
        {
            taskIndex = 0;
        }
        else
            taskIndex++;  //Task 1 is at index 1. Index 0 is skipped on the first loop.

        npc1Tasks[taskIndex].SetActive(true);
    }

    public void TaskExit()
    {
        npc1Tasks[taskIndex].SetActive(false);
        cameraControls.enabled = true;
        controller.enabled = true;
    }

    //Tracking if the player clicks no on a task
    public void ClickedNo()
    {
        clickedNo++;
        Invoke("TaskExit", 0);
    }


//Below are the GUI for messages when returning to the NPC
    //If task complete then Success message appears
    IEnumerator SuccessMessage()
    {
        successMsg.SetActive(true);
        yield return new WaitForSeconds(2f);
        successMsg.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        taskComplete[taskIndex] = true;
        taskActive[taskIndex] = false;
        AddData();
    }
    IEnumerator CompletedAll()
    {
        allTasksMsg.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        allTasksMsg.SetActive(false);
        this.enabled = false;
    }
    IEnumerator ComeBack()
    {
        comeBack.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        comeBack.SetActive(false);
    }

//Below is all UI for Tasks 1-3

    //Button to start Task1
    public void Task1()
    {
        npc1Tasks[taskIndex].SetActive(false);
        task1b.gameObject.SetActive(true);
        
    }

    //This is the "Ok" button click on Task1b. 
    public void Task1Started()  
    {
        dataScript.taskRunning = true;
        taskActive[taskIndex] = true;
        cat.gameObject.SetActive(true);
        task1b.gameObject.SetActive(false);
        Invoke("TaskExit", 0);
    }

    //Buttons to start task 2
    public void Task2()
    {
        npc1Tasks[taskIndex].SetActive(false);
        task2b.gameObject.SetActive(true);
    }

    //This is the "Ok" button click on Task2b.
    public void Task2Started()
    {
        dataScript.taskRunning = true;
        taskActive[taskIndex] = true;
        task2b.gameObject.SetActive(false);
        Invoke("TaskExit", 0);
    } 

    void AddData()
    {
        //Doesn't work just yet 
        if(taskComplete[taskIndex] == true)
        {
            dataScript.indexOfCompleteTasks.Add(taskIndex);
        }
    }
}

