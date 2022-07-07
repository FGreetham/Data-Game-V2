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
    [SerializeField] private DoorLock doorScript;
    [SerializeField] private PickUp pickUp;

    [Header("Task Status")]
    public bool task1Complete;
    public bool task2Complete;
    public bool taskRunning;
 

    //Variable Set Up
    [SerializeField] private int allCollectables;
    public List<string> interactables;
    public List<int> indexOfCompleteTasks;
       

    [SerializeField] private int explorePoint;
    [SerializeField] private int completionPoint;
    public int[] taskCollectables;
    public int[] taskInteractables;

    public int catsFound = 0;
    public int cabbagesCollected = 0;
    public int tomatoesCollected = 0;

    [Header("JSON Data")]
    string filename = "data.json";
    string path;
    GameData gameData = new GameData();

     void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);


        //Trying to get time when player starts game.
        var timeOnAwake = System.DateTime.Now;
    }

    void Start()
    {
        path = Application.persistentDataPath + "/" + filename;
        print(path);
    }


 
    void Update() 
    {
        //allCollectables = vegScript.cabbageCount + vegScript.tomatoCount;
    
        if(Input.GetKeyDown(KeyCode.N))
        {
           SetData();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReadData();
        }
    }

    public void SetData()
    {
        //Player Identifiers
        gameData.date = System.DateTime.Now.ToShortDateString();
        gameData.time = System.DateTime.Now.ToShortTimeString();
        gameData.playerName = PlayerPrefs.GetString("PlayerName");
        //Trying to work out time player spent on game.
        //gameData.timePlayed = System.DateTime.Now - timeOnAwake;


        //Player Data
        gameData.didPlayerCloseDoor = doorScript.doorClosed;
        gameData.didPlayerLockDoor = doorScript.doorLocked;
        gameData.numberOfTasksPlayerRejected = tasks.clickedNo;
        gameData.moreThanOneAttemptToLock = doorScript.attempts;

        //Having issues with converting bool to int for whether the tasks are active or complete.
        //gameData.numberOfTasksStillRunning = tasks.taskActive[tasks.taskIndex].;
       // gameData.numnerOfTasksCompleted = tasks.taskComplete[tasks.taskIndex];
        gameData.indexOfTasksCompleted = indexOfCompleteTasks;

        gameData.itemsInteractedWith = interactables;

        gameData.totalItemsPickedUp = cabbagesCollected + tomatoesCollected;
        gameData.cabbagesCollected = cabbagesCollected;
        gameData.tomatosCollected = tomatoesCollected;

        SaveData();
    }
    void SaveData()
    { 
        string savedContents = JsonUtility.ToJson(gameData, true);
        System.IO.File.WriteAllText(path, savedContents);
    }

    //Loading the data back in
    void ReadData()
    {
        try
        {//Check if files exists
            if (System.IO.File.Exists(path))
            {
                string savedContents = System.IO.File.ReadAllText(path);
                gameData = JsonUtility.FromJson<GameData>(savedContents);
            }
            else
            {
                print("Unable to read the data, file does not exist");
                gameData = new GameData();
            }
        }
        //If file gets corrupted
        catch (System.Exception ex)
        {
            Debug.Log(ex.Message);
        }
        
    }

//Below will be deleted. Just for reference.
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
