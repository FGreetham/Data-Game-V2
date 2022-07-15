using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelbarrowScript : Interactable
{
    public PlayerController player;
   
    [SerializeField] private Transform pushPoint;
    private GameObject pushedObject;
    private bool pickedUp;

    void Start()
    {
        pickedUp = false;
    }


    public override void OnPlayerInteract()
    {
        if (pickedUp == false)
        {
            pushedObject = this.gameObject;
            pickedUp = true;
            UseWheelbarrow();
        }


        else if (pickedUp == true)
        {
            pushedObject.transform.parent = null;
            // pushedObject.transform.position - new y coord to put on floor
            pushedObject.transform.rotation = pushPoint.rotation * Quaternion.Euler(0f, 0, 0);
            player.speed = player.speed * 2;
            pickedUp = false;

        }
    }
    void UseWheelbarrow()
    {
        pushedObject.transform.position = pushPoint.position;
        pushedObject.transform.parent = pushPoint.transform;
        pushedObject.transform.rotation = pushPoint.rotation * Quaternion.Euler(8f, 0, 0);
        player.speed = player.speed / 2;
        DataManagerScript.instance.interactables.Add(pushedObject.name);
    }
    
}
