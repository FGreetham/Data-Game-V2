using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpMenuButtons : MonoBehaviour
{
    public CollectTheItem collectable;
    public void PickUpItem()
    //Menu buttons only work for one script at a time.. how can i set the buttons to work for all?
    {
        
    }

    public void DontPickUp()
    {
       //collectable.HideMenu();
    }
}
