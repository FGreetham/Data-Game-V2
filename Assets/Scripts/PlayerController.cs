using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 2.0f;
    public float jumpHeight = 3.0f;
    public float gravity = -9.8f;
    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    public Transform pushPoint;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        Invoke("WheelbarrowPush", 0);
        /* if (Input.GetKeyDown(KeyCode.J))
          {
              velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
              // isGrounded check to make only jump once stops it from jumping at all.
          } */
    }

    /*private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Vector3 offset = new Vector3(0, 0f, 0);
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        if (hit.collider.CompareTag("Movable"))
        {
            Debug.Log("Movable wheelbarrow");
            //this.transform.position = hit.collider.transform.position + offset;
            hit.collider.attachedRigidbody.velocity = pushDir * (speed/2);
        }
    } */

    void WheelbarrowPush()
    {
        float pickUpRange = 10f;
        GameObject pushedObject;

        //WHY DOES IT NOT ALLOW ME TO CHECK IF SOMETHING IS THERE?

        /* if (pushedObject != null && Input.GetKeyDown(KeyCode.D)) 
        {
            pushedObject.transform.parent = null;
            speed = speed * 2;
            return;
        } */

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out RaycastHit hit, pickUpRange))
        {
            if (hit.collider.gameObject.tag == "Movable")
            {
                pushedObject = hit.collider.gameObject;
                pushedObject.transform.position = pushPoint.position;
                pushedObject.transform.parent = pushPoint.transform;
                pushedObject.transform.rotation = pushPoint.rotation * Quaternion.Euler(10f, 0, 0);

                speed = speed / 2;
                //Maybe add on screen text to say you have to hold the click

            }

        }

    }
}
