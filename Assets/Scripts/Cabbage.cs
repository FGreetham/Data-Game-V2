using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cabbage : MonoBehaviour
{
    /*3 PROBLEMS: 1. I want it to only work after clicking on the object, but this breaks the destroy object function. Is there a way to destroy object that was clicked to activate the text?
    2. On Y click, only destroys object when raycast colliding with object. Can I deltete object that was hovered over to activate the text?
    3. The N button is clicked, but I can't get the text to turn off. */

    public TextMeshProUGUI pickUpText;
    RaycastHit hit;
    private int cabbageCount;

    
    void Update()
    {
        //if (Input.GetMouseButtonDown(0)) 
        // I WANT TO USE THIS BELOW FEATURE ONLY WHEN MOUSE HAS BEEN CLICKED TO STOP RAYCAST BEING ACTIVE ALL THE TIME BUT IT WON'T ALLOW PickUpItem Y or N to work.
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                {
                    //Only objects tagged "Cabbage"
                    if (hit.collider.gameObject.tag == "Cabbage")
                    {
                        Invoke("PickUpItem", 0);
                    
                    }

                }

            }
        
    }

    void PickUpItem()
    {
        pickUpText.gameObject.SetActive(true);
        //This brings up the text, 

        if (Input.GetKeyDown(KeyCode.Y))
        {   //Only destroys Gameobject that the raycast hits the collider of, it doesn't destroy the prefab. But I have to be hovering over it - how do I detroy JUST the game object that was once hovered over?  
            Destroy(hit.collider.gameObject); 
            pickUpText.gameObject.SetActive(false);
            Debug.Log("Y pressed");
            UpdateCabbageCount(1);

        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log("N pressed");
            pickUpText.gameObject.SetActive(false);
        } //Click N registers (if not using on mouse down, but the PickUpItem method resets so never actually goes away.


    }

    void UpdateCabbageCount(int countToAdd)
    {
        cabbageCount += countToAdd;
        Debug.Log("Cabbages = " + cabbageCount);
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
            } */
}