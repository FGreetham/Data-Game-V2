using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankTrigger : MonoBehaviour
{
    //Only place the wooden planks if the player in trigger zone near the shed.
    private void OnTriggerEnter(Collider other)
    {
        DataManagerScript.instance.withinTargetRange = true;
        Debug.Log("Within range");
    }
    private void OnTriggerExit(Collider other)
    {
        DataManagerScript.instance.withinTargetRange = false;
    }
}
