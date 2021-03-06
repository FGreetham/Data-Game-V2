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
    [SerializeField] private PickUp pickUp;


    //Variable Set Up
    [Header("Collectable Variables")]
    public List<string> interactables;
    public int catsFound = 0;
    public int cabbagesCollected = 0;
    public int tomatoesCollected = 0;

    [Header("Task Variables")]
    public List<int> indexOfCompleteTasks;
    public bool[] taskActive = new bool[3];
    public bool[] taskComplete = new bool[3];
    public bool allTasksComplete;
    // public int[] taskCollectables;
    // public int[] taskInteractables;
    public int clickedNo;

    public bool doorClosed;
    public bool doorLocked;
    public int doorAttempts;



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
        
    
        if(Input.GetKeyDown(KeyCode.N))
        {
           SaveData();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ReadData();
        }
    }

    public void SaveData()
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
       // gameData.numberOfTasksCompleted = tasks.taskComplete[tasks.taskIndex];
        gameData.indexOfTasksCompleted = indexOfCompleteTasks;

        gameData.itemsInteractedWith = interactables;

        gameData.totalItemsPickedUp = vegScript.cabbageCount + vegScript.tomatoCount;
        gameData.cabbagesCollected = vegScript.cabbageCount;
        gameData.tomatosCollected = vegScript.tomatoCount;
        SetDataToJSON();
    }
    public void SetDataToJSON()
    { 
        string savedContents = JsonUtility.ToJson(gameData, true);
        System.IO.File.WriteAllText(path, savedContents);
    }

    //Loading the data back in
   public void ReadData()
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

}
