using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManagerScript : MonoBehaviour
{
    //References
    [Header("Script References")]
    public static DataManagerScript instance;
    [SerializeField] private CatFound catScript;
    [SerializeField] private TaskScript tasks;
    [SerializeField] private Vegetables vegScript;
    [SerializeField] private DoorLock doorScript;


    [Header("Task Status")]
    public bool task1Complete;
    public bool task2Complete;
    public bool taskRunning;

    //Variable Set Up
    [SerializeField] private int allCollectables;
    public List<string> interactables; 

    [SerializeField] private int explorePoint;
    [SerializeField] private int completionPoint;
    public int[] taskCollectables;
    public int[] taskInteractables;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        Debug.Log("Awake: " + this.gameObject);
    }


 
    void Update() 
    {
        allCollectables = vegScript.cabbageCount + vegScript.tomatoCount;

        //Task 1 - Collect the cat
        if (catScript.catCollected)
        {
            taskRunning = false; 
            //THIS IS IN UPDATE SO IF YOU COMPLETE TASK 1, DOESN'T SAY TASK RUNNING TRUE FOR SUBSEQUENT TASKS
            task1Complete = true;
            completionPoint++;
        }
        //Task 2
        if (vegScript.tomatoCount >= 5)
        {
            task2Complete = true;
            taskRunning = false;
            completionPoint++;
        }

        /*
        if (vegScript.tempCollectable != null)
        {
            

 
            if (taskRunning == true)
            {
                taskCollectables[tasks.taskIndex]++;
              
            }
            else
            {
                explorePoint++;
            }
        }*/

    }

    public void DataToRemember()
    {
        //How many times player clicked no on a task?
        Debug.Log(tasks.clickedNo);

        //How much the player explored?
        Debug.Log(explorePoint);
        Debug.Log("Player picked up " + allCollectables + " object(s).");

        //How many tasks did the player complete?
        Debug.Log("Player completed " + completionPoint + " task(s).");
        if (task1Complete == true)
        {
            Debug.Log("Task 1 was completed");
        }
        if (task2Complete == true)
        {
            Debug.Log("Task 2 was completed");
        }

        //Did they leave without finishing a task?
        if(taskRunning == true)
        {
            Debug.Log("Task left uncomplete");
        }

        if(doorScript.doorLocked == true)
        {
            Debug.Log("Locked the door");
        }
        if(doorScript.doorLocked == false && doorScript.doorClosed)
        {
            Debug.Log(PlayerPrefs.GetString("PlayerName") + " closed but didn't lock the door.");
        }

    }
}
