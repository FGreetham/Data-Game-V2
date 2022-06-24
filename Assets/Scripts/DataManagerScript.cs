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


    [Header("Task Status")]
    public bool task1Complete;
    public bool task2Complete;
    public bool taskRunning;

    //Variable Set Up
    [SerializeField] private int allCollectables;
    private int allInteractables;
    [SerializeField] private int explorePoint;
    [SerializeField] private int completionPoint;
    public int[] taskCollectables;
    public int[] taskInteractables;

    //LayerMask collectables = LayerMask.GetMask("Collectables");

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


    //I DON'T THINK THE BELOW SHOULD BE IN UPDATE... WOULD A NORMAL METHOD DO?
    void Update() 
    {
        //Task 1 - Collect the cat
        if (catScript.catCollected)
        {
            taskRunning = false; 
            //THIS IS IN UPDATE SO IF YOU COMPLETE TASK 1, DOESN'T SAY TASK RUNNING TRUE FOR SUBSEQUENT TASKS
            task1Complete = true;
            completionPoint++;
        }
        if (vegScript.tomatoCount >= 5)
        {
            task2Complete = true;
            taskRunning = false;
            completionPoint++;
        }


        //WHOLE AREA BELOW NEEDS WORK - REGISTERING WHEN A COLLECTABLE OBJECT IS PICKED UP UNDER WHICH ACTIVE TASK
        //   if (gameObject.tag == "Collectable") //Should this reference if tagged object destroyed,
        //or should this be on a different script and reference the allCollectables from there?
        if (vegScript.tempCollectable != null)
        {
            allCollectables += 1; // Need to make this so only adds one when tempCollectable first becomes null... 
            //Or only when PickUpItem invoked..
            if (taskRunning == true)
            {
                // tasks.taskIndex = taskCollectables[tasks.taskIndex];
                //SHOULD THIS BE A DICTIONARY... SO WHEN TASK 2 = ACTIVE, AND COLLECTIBLES +1, IT ADDS A VALUE TO THE KEY TASK 2?

                //***Does it need to be added to that particular task? Or just the taskCollectabled in general? JUST IN GENERAL

            }
            else
            {
                explorePoint++;
            }
        }

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

        
    }
}
