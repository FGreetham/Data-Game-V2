using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Vegetables : Interactable
{
    [SerializeField] private CameraController cameraControls;
    [SerializeField] private PlayerController player;
    [SerializeField] private GameObject pickUpMenu;

    private void Start()
    {
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


    public void PickUpItem()
    {
        UpdateCount();
        HideMenu();

        //If i had the script on the player - the buttons would work on the Pick Up Menu, but to work out which object to delete - needs to be in a temp collectable.
        //player.tempCollectable.SetActive(false);
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