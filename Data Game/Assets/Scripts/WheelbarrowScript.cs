using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelbarrowScript : MonoBehaviour
{
    public PlayerController player;

    private float pickUpRange = 10f;
    private GameObject pushedObject;
    public Transform pushPoint;


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
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out RaycastHit hit, pickUpRange))
        {
            if (hit.collider.gameObject.tag == "Movable")
            {
                pushedObject = hit.collider.gameObject;
                pushedObject.transform.position = pushPoint.position;
                pushedObject.transform.parent = pushPoint.transform;
                pushedObject.transform.rotation = pushPoint.rotation * Quaternion.Euler(10f, 0, 0);

                player.speed = player.speed / 2;
               

            }

        }
    }
}
