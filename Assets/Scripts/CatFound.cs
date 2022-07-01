using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFound : MonoBehaviour
{
    public bool catCollected;
    private float raycastRange = 20f;

    //Click on the Cat to complete the task
    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out RaycastHit hit, raycastRange))
        {
            if (hit.collider.gameObject.CompareTag("Cat")) 
            {
                catCollected = true;
                gameObject.SetActive(false);
            }

        }
    }


}
