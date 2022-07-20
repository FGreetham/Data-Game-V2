using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaskScript : MonoBehaviour
{
    [Header("Script References")]
    private CameraController cameraControls;
    private CharacterController playerController;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject cat;

    [Header("Task Index")]
    public GameObject[] npc1Tasks;
    public int taskIndex;
    public bool[] taskActive = new bool[3];
    public bool[] taskComplete = new bool[3];

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
      //  cameraControls.GetComponent<CameraController>();
        cameraControls = FindObjectOfType<CameraController>();
        playerController = FindObjectOfType<CharacterController>();
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

        //If task completed, "success" message appears and data is added.
        //If task is active, "Come back when you're done" message appears.
        if (taskActive[taskIndex] == true)
        {
            if (taskIndex == 1)
            {
                if (DataManagerScript.instance.catsFound >= 1)
                {
                    StartCoroutine("SuccessMessage");
                }
                else
                    StartCoroutine("ComeBack");
            }
            else if (taskIndex == 2)
            {
                if (DataManagerScript.instance.tomatoesCollected >= 5)
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
            CheckIfComplete();
        }
    }

    void CheckIfComplete()
    {
        MoveThroughTasks(1);

        //If the current task isn't complete, will give the option to start the task at that index.
        if (taskComplete[taskIndex] == false)
        {
            cameraControls.enabled = false;
            playerController.enabled = false;
            npc1Tasks[taskIndex].SetActive(true);
        }

        //If task at current index is completed already, use recursion to move through array of tasks again and recheck.
        else if(taskComplete[taskIndex] == true)
        {
            CheckIfComplete();
        }
    }

    public void MoveThroughTasks(int increase)
    {
       
        taskIndex = taskIndex % npc1Tasks.Length;

        if (npc1Tasks.Length - 1 == taskIndex)
        {
            taskIndex = 0;
        }
        else
            //Task 1 is at index 1. Index 0 is skipped on the first loop and then it iterates back through.
            taskIndex += increase; 
    }



    //Below are the GUI for messages when returning to the NPC

    //If task complete then Success message appears
    IEnumerator SuccessMessage()
    {
        if (DataManagerScript.instance.tasksComplete >= 2)
        {
            StartCoroutine("CompletedAll");
        }

        else
        {
            successMsg.SetActive(true);
            yield return new WaitForSeconds(2f);
            successMsg.SetActive(false);
            yield return new WaitForSeconds(0.5f);
            AddData();
        }
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
    void AddData()
    {
        taskComplete[taskIndex] = true;
        taskActive[taskIndex] = false;
        DataManagerScript.instance.taskRunning = false;
        DataManagerScript.instance.indexOfCompleteTasks.Add(taskIndex);
        DataManagerScript.instance.tasksComplete++;
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
        UpdateTaskStatus();
        cat.gameObject.SetActive(true);
        task1b.gameObject.SetActive(false);
        TaskExit();
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
        UpdateTaskStatus();
        task2b.gameObject.SetActive(false);
        TaskExit();
    }

    void UpdateTaskStatus()
    {
        taskActive[taskIndex] = true;
        DataManagerScript.instance.taskRunning = true;
    }

    public void TaskExit()
    {
        npc1Tasks[taskIndex].SetActive(false);
        cameraControls.enabled = true;
        playerController.enabled = true;
    }

    //Tracking if the player clicks no on a task
    public void ClickedNo()
    {
        DataManagerScript.instance.clickedNo++;
        TaskExit();
    }
}

