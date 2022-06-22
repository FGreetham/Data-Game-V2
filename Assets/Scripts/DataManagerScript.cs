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
    public bool taskRunning;

    //Variable Set Up
    [SerializeField] private int allCollectables;
    private int allInteractables;
    [SerializeField] private int explorePoint;
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


    // Update is called once per frame
    void Update()
    {
        //Task 1 - Collect the cat
        if (catScript.catCollected)
        {
            taskRunning = false;
            task1Complete = true;
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
            }
            else
            {
                explorePoint++;
            }
        }
        
    }
}
