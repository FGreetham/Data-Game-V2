using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Vegetables : MonoBehaviour
{
 
    public GameObject pickUpMenu;
    RaycastHit hit;
    public GameObject tempCollectable;
    public int cabbageCount;
    public int tomatoCount;
    public CameraController cameraControls;
    public float raycastRange = 7f;


    private void Start()
    {
        cameraControls.GetComponent<CameraController>();
    }
    void Update()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit, raycastRange))
            {
                {
                //Only objects tagged "Cabbage"
                if (hit.collider.gameObject.tag == "Cabbage" || hit.collider.gameObject.tag == "Tomato")
                {
                    tempCollectable = hit.collider.gameObject;
                    //This brings up the text
                    pickUpMenu.gameObject.SetActive(true);
                    cameraControls.enabled = false;
                }

                }

            }


    }
    public void PickUpItem()
    {
        //Destroys object that was hit by the raycast earlier. 
        Debug.Log("Y pressed");
        UpdateVegCount(1); 
        Destroy(tempCollectable);
        pickUpMenu.gameObject.SetActive(false);
        cameraControls.enabled = true;

    }

    public void DontPickUp()
    {
        Debug.Log("N pressed");
        pickUpMenu.gameObject.SetActive(false);
        cameraControls.enabled = true;
    }

    public void UpdateVegCount(int countToAdd)
    {
        if (tempCollectable.gameObject.tag == "Cabbage")
            
        {
            cabbageCount += countToAdd;
            Debug.Log("Cabbages = " + cabbageCount);
        }

        if (tempCollectable.gameObject.tag == "Tomato")
        {
            tomatoCount += countToAdd;
            Debug.Log("Tomatoes = " + tomatoCount);
        }
    }



    /* DRAFT CODE FOR REF: 
        This code works to delete object when you simply click on the cabbage, no frills like text on the screen...
      if (Input.GetMouseButtonDown(0))
            {   RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    //Only objects tagged "Cabbage"
                    if (hit.collider.gameObject.tag == "Cabbage")
                    {
                        //Only destroys Gameobject that the raycast hits the collider of, it doesn't destroy the prefab.  
                        Destroy(hit.collider.gameObject);
                        //UpdateCabbageCount(1);

                    }


                }
            } 
    
    Y or N click 
     public void PickUpItem()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {   //Destroys object that was hit by the raycast earlier. 
            Destroy(tempCollectible);
            pickUpMenu.gameObject.SetActive(false);
            Debug.Log("Y pressed");
            UpdateVegCount(1);

        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("N pressed");
            pickUpMenu.gameObject.SetActive(false);
        }


    }
        void UpdateVegCount(int countToAdd)
    {
        if (hit.collider.gameObject.tag == "Cabbage")
            
        {
            cabbageCount += countToAdd;
            Debug.Log("Cabbages = " + cabbageCount);
        }

        if (hit.collider.gameObject.tag == "Tomato")
        {
            tomatoCount += countToAdd;
            Debug.Log("Tomatoes = " + tomatoCount);
        }
    }
     */
}