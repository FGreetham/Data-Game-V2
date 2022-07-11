using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelbarrowScript : MonoBehaviour
{
    public PlayerController player;
    [SerializeField] private DataManagerScript data;
    private float pickUpRange = 10f;
    private GameObject pushedObject;
    public Transform pushPoint;
    public bool pickedUp;

    void Start()
    {
        pickedUp = false;
    }
    // Update is called once per frame
    void Update()
    {
        //WHY DOES IT NOT ALLOW ME TO CHECK IF SOMETHING IS THERE?

        /* if (pushedObject != null && Input.GetKeyDown(KeyCode.D)) 
        {
            pushedObject.transform.parent = null;
            speed = speed * 2;
            return;
        } */
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out RaycastHit hit, pickUpRange) && pickedUp == false)
        {
            if (hit.collider.gameObject.tag == "Interactable")
            {
                pushedObject = hit.collider.gameObject;
                pickedUp = true;
                UseWheelbarrow();
            }
        }

        if(pickedUp == true && Input.GetKeyDown(KeyCode.L))
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
        data.interactables.Add(pushedObject.name);
    }
    
}
