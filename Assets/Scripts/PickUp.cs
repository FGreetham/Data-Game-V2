using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private LayerMask pickUpMask;
    [SerializeField] private float pickUpRange; 
    [SerializeField] private Transform pickUpTarget;

    
    public Rigidbody currentObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    /*  void Update()
      {

          if (currentObject)
          {
              currentObject.useGravity = true;
              currentObject = null;
              return;
          } 

            if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit HitInfo, pickUpRange, pickUpMask))
            {
                currentObject = HitInfo.rigidbody;
                currentObject.useGravity = false;
            }
        }
}*/

    void OnMouseDown()
    {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, pickUpRange, pickUpMask))
            {
                currentObject = hit.rigidbody;
                currentObject.useGravity = false;
            }
        
    }

    private void OnMouseUp()
    {
        currentObject.useGravity = true;
        currentObject = null;
        return;
    }

    void FixedUpdate()
    {
        if (currentObject)
        {
            Vector3 directionToPoint = pickUpTarget.position - currentObject.position;
            float distanceToPoint = directionToPoint.magnitude;
            float speed = 12f;

            currentObject.velocity = directionToPoint * speed * distanceToPoint;
        }

    }
}
