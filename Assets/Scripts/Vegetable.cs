using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Put this script on every vegetable GameObject
public class Vegetable : Collectable
{
    private GameObject pickUpMenu;
    private CameraController cameraControls;

    private void Start()
    {
        // Instead of setting references on every instance, we can search for GameObjects with a given name, or components of a given type
        // This is easier than dragging references around, but also means that for example you could spawn vegetables at runtime, and they'd be able to set themselves up
        cameraControls= GameObject.FindObjectOfType<CameraController>();
        pickUpMenu = GameObject.Find("Pick this up menu");
    }

    public override void OnPlayerCollect()
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
        Debug.Log("Y pressed");

        HideMenu();

        if (tag == "Cabbage")
        {
            DataManagerScript.instance.cabbagesCollected++;
        }
        else if (tag == "Tomato")
        {
            DataManagerScript.instance.tomatoesCollected++;
        }

        gameObject.SetActive(false);
    }

    public void DontPickUp()
    {
        Debug.Log("N pressed");

        HideMenu();
    }
}