using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Interactable
{
    private GameObject pickedUpObject;
    [SerializeField] private Transform pickUpPoint;
    [SerializeField] private DataManagerScript data;

    public override void OnPlayerInteract()
    {
        if(pickedUpObject == null)
       {
           pickedUpObject = this.gameObject;
           pickedUpObject.GetComponent<MeshCollider>().enabled = false;
           pickedUpObject.GetComponent<Rigidbody>().useGravity = false;
           pickedUpObject.transform.position = pickUpPoint.position;
           pickedUpObject.transform.rotation = pickUpPoint.rotation;
           pickedUpObject.transform.parent = GameObject.FindGameObjectWithTag("Pick Up").transform;
       }
        /*
            else if (pickedUpObject != null)
              {
                  pickedUpObject.GetComponent<MeshCollider>().enabled = true;
                  pickedUpObject.GetComponent<Rigidbody>().useGravity = true;
                  pickedUpObject.transform.parent = null;
                  DataManagerScript.instance.interactables.Add(pickedUpObject.name);
                 // data.interactables.Add(pickedUpObject.name);
                  return;
              }*/
    }

   /*  void OnMouseDown()
      {
          Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
          if (Physics.Raycast(ray, out RaycastHit hit, pickUpRange))
          {
              pickedUpObject = hit.collider.gameObject;
              pickedUpObject.GetComponent<MeshCollider>().enabled = false;
              pickedUpObject.GetComponent<Rigidbody>().useGravity = false;
              pickedUpObject.transform.position = pickUpPoint.position;
              pickedUpObject.transform.parent = GameObject.FindGameObjectWithTag("Pick Up").transform;
          }

      } */
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
