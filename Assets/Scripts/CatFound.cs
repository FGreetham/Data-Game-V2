using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFound : Interactable
{

    //Click on the Cat to complete the task
    public override void OnPlayerInteract()
    {
        DataManagerScript.instance.catsFound++;
        gameObject.SetActive(false);
    }

}
