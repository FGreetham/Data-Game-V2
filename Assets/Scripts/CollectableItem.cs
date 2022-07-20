using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : Interactable
{
     private MenuManager menuManager;

    private void Start()
    {
        menuManager = FindObjectOfType<MenuManager>();
    }

    public override void OnPlayerInteract()
    {
        menuManager.ShowPickUpMenu(this);
    }

    public void PickUpItem()
    {
        UpdateCount();
        gameObject.SetActive(false);
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
