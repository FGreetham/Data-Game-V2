using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour
{
    //Variables to Close the Door
    RaycastHit hit;

    [SerializeField] private float raycastRange = 7;
    
    private float openRotation = -140f;
    private float closedRotation = 140f;
  
 

    void OnMouseDown()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, raycastRange) && hit.collider.gameObject.tag == "Door")
        {
            //Debug.Log("Door hit");

            if (transform.rotation.z >= 170f) //The 170f part doesn't register no matter what i do. Why is it any different to below?
            {
                transform.Rotate(0, 0, -140f);
                Debug.Log("Door open");
            }

            //ONLY THIS ONE WORKS... IT KEEPS MOVING AROUND THIS WAY
           else if (transform.rotation.z <= 40f)
            {
               
                transform.Rotate(0, 0, closedRotation);
                Debug.Log("Door closed"); 
            } 

            else
            {
                //STOP MOVING
                transform.rotation = transform.rotation;
            }

        }

    }

    // gameObject.transform.rotation = Quaternion.Euler(rotationX, 0f, rotationZ);

}
