using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTheItem : Interactable
{
    public CameraController cameraControls;
    [SerializeField] private GameObject pickUpMenu;


    private void Start()
    {
      //  pickUpMenu = GameObject.Find("PickUpMenu");
        cameraControls.GetComponent<CameraController>();
        
    }

    public override void OnPlayerInteract()
    {
        ShowMenu();
    }

    private void ShowMenu()
    {
        pickUpMenu.gameObject.SetActive(true);
        cameraControls.enabled = false;
    }

    private void HideMenu()
    {
        pickUpMenu.gameObject.SetActive(false);
        cameraControls.enabled = true;
    }

    //Nearly works but the buttons on PickUpMenu are only assigend to one script at a time.. 
    //Fine if only on 1 object but as this script is for multiple objects, it doesn't work.
    //How can I make the buttons work when needing to be assigned to all collectable objects?
    public void PickUpItem()

    {
        UpdateCount();
        HideMenu();
        
        gameObject.SetActive(false);
    }

    public void DontPickUp()
    {
        HideMenu();
    }

    public void UpdateCount()
    {
        if (tag == "Cabbage")

        {
            DataManagerScript.instance.cabbagesCollected++;
        }

        if (tag == "Tomato")
        {
            DataManagerScript.instance.tomatoesCollected++;
            print("Tomatoes = " + DataManagerScript.instance.tomatoesCollected);
        }

        if (tag == "Cat")
        {
            DataManagerScript.instance.catsFound++;
        }
    }
}
