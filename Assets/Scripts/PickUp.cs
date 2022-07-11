using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject pickedUpObject;
    [SerializeField] private float pickUpRange;
    [SerializeField] private Transform pickUpPoint;
    [SerializeField] private DataManagerScript data;
    [SerializeField] private GameData gameData;

    /*Semi-works. Has to be attached to the gameobject to pick up. 
     * Still floats - can't get physics to turn off
     * When it lands - it falls through the ground sometimes. Is this a problem with the terrian physics? */

    void OnMouseDown()
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

    }

    private void OnMouseUp()
    {
        if (pickedUpObject)
        {
            pickedUpObject.transform.parent = null;
            pickedUpObject.GetComponent<MeshCollider>().enabled = true;
            pickedUpObject.GetComponent<Rigidbody>().useGravity = true;
            data.interactables.Add(pickedUpObject.name);
            return;
        }

    }
}
