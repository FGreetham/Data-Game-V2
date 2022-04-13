using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFound : MonoBehaviour
{
    public bool catCollected;
    private float raycastRange = 10f;


    /* DISAPPEARS BEFORE YOU EVEN SEE IT
     * private void OnTriggerEnter(Collider other)
     {
         catCollected = true;
         Debug.Log("Cat Found and Task 1 Complete");
         gameObject.SetActive(false);

     } */

    //Click on the Cat to complete the task
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out RaycastHit hit, raycastRange))
        {
            if (hit.collider.gameObject)
            {
                catCollected = true;
                Debug.Log("Cat Found and Task 1 Complete");
                gameObject.SetActive(false);
            }

        }
    }


}
