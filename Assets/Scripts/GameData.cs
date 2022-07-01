using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public string playerName;
    public string date = "";
    public string time = "";
    public string timePlayed2;
    public Time timePlayed;

    public bool didPlayerCloseDoor;
    public bool didPlayerLockDoor;
    public int moreThanOneAttemptToLock;
    public int numberOfTasksPlayerRejected;
    public int numberOfTasksStillRunning;
    public int numnerOfTasksCompleted;
    public List<int> indexOfTasksCompleted;
    public int totalItemsPickedUp;
    public int tomatosCollected;
    public int cabbagesCollected;

    public List<string> itemsInteractedWith;


}