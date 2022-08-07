using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public string playerName;
    public string date = "";
    public string time = "";
   // public Time timePlayed;

    public bool didPlayerCloseDoor;
    public bool didPlayerLockDoor;
    public int numberOfAttemptsToLockDoor;
    public int numberOfTasksCompleted;
    public List<int> indexOfTasksCompleted;
    public int numberOfTimesPlayerClickedNoOnTask;
    public bool isATaskStillRunning;
    public int totalItemsPickedUp;
    public int tomatosCollected;
    public int cabbagesCollected;
    public int catsCollected;
    public int planksPlacedOnTarget;

    public List<string> itemsInteractedWith;


}