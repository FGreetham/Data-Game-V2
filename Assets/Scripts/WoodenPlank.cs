using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodenPlank : Interactable
{
    private GameObject pickedUpObject;
   // [SerializeField] private Transform pickUpPoint;
    private GameObject point;
    public GameObject plankTarget;
   
    
    //private int distanceFromTarget; //Can I work out how close you can get?
    //Or do a bool for on trigger enter...

    private bool withinTargetRange;


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
            if (withinTargetRange == true)
            {
                pickedUpObject.transform.parent = null;
                pickedUpObject.transform.position = plankTarget.transform.position;
                pickedUpObject.transform.rotation = plankTarget.transform.rotation;
                DataManagerScript.instance.interactables.Add(pickedUpObject.name);
                pickedUpObject = null;
                //If plank target less than a certain distance from the plank...
                //put the plank at that transform (position and rotation)
                Debug.Log(gameObject.name + " on target");
            }
            else
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

    private void OnTriggerEnter(Collider other)
    {
        withinTargetRange = true;
        Debug.Log("Within range");
    }
}
