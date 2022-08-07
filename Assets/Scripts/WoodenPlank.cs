using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenPlank : Interactable
{
    private GameObject pickedUpObject;
    private GameObject point;
    public GameObject plankTarget;

    void Start()
    {
        point = GameObject.Find("Pick Up Point");
    }    
    public override void OnPlayerInteract()
    {
        if (pickedUpObject == null)
        {
            pickedUpObject = this.gameObject;
            pickedUpObject.GetComponent<MeshCollider>().enabled = false;
            pickedUpObject.GetComponent<Rigidbody>().useGravity = false;
            pickedUpObject.GetComponent<Rigidbody>().isKinematic = true;
            pickedUpObject.transform.position = point.transform.position;
            pickedUpObject.transform.rotation = point.transform.rotation;
            pickedUpObject.transform.parent = GameObject.FindGameObjectWithTag("Pick Up").transform;
        }
    }
    private void OnMouseUp()
    {
        if (pickedUpObject)
        {
            if (DataManagerScript.instance.withinTargetRange == true)
            {
                DataManagerScript.instance.planksPlaced++;
                pickedUpObject.transform.parent = null;
                pickedUpObject.transform.position = plankTarget.transform.position;
                pickedUpObject.transform.rotation = plankTarget.transform.rotation;
                DataManagerScript.instance.interactables.Add(pickedUpObject.name);
                pickedUpObject = null;

                Debug.Log(gameObject.name + " on target");
            }
            else
            {
                pickedUpObject.GetComponent<MeshCollider>().enabled = true;
                pickedUpObject.GetComponent<Rigidbody>().useGravity = true;
                pickedUpObject.GetComponent<Rigidbody>().isKinematic = false;
                pickedUpObject.transform.parent = null;
                DataManagerScript.instance.interactables.Add(pickedUpObject.name);
                pickedUpObject = null;
                return;
            }
        }
    }
}
