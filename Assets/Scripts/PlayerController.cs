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

        /* if (Input.GetKeyDown(KeyCode.J))
          {
              velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
              // isGrounded check to make only jump once stops it from jumping at all.
          } */
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        //Vector3 offset = new Vector3(0, 0f, 0);
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        if (hit.collider.CompareTag("Movable"))
        {
            Debug.Log("Movable wheelbarrow");
            //this.transform.position = hit.collider.transform.position + offset;
            hit.collider.attachedRigidbody.velocity = pushDir * (speed/2);
        }
    }
}
