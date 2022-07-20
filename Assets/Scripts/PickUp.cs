using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Interactable
{
    private GameObject pickedUpObject;
   // [SerializeField] private Transform pickUpPoint;
    private GameObject point;


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
            pickedUpObject.transform.position = point.transform.position;
            pickedUpObject.transform.rotation = point.transform.rotation;
            pickedUpObject.transform.parent = GameObject.FindGameObjectWithTag("Pick Up").transform;
        }
    }
    private void OnMouseUp()
    {
        if (pickedUpObject)
        {
            
            pickedUpObject.GetComponent<MeshCollider>().enabled = true;
            pickedUpObject.GetComponent<Rigidbody>().useGravity = true;
            pickedUpObject.transform.parent = null;
            DataManagerScript.instance.interactables.Add(pickedUpObject.name);
            pickedUpObject = null;
            return;
        }

    } 
}
