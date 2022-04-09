using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //Character movement variables
    public CharacterController controller;
    public float speed = 2.0f;
    public float jumpHeight = 3.0f;
    public float gravity = -9.8f;
    Vector3 velocity;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;


    //NPC Task related variables
    public bool playerInsideTrigger;
    public GameObject tempNpc;
    public TextMeshProUGUI pressT;
    [SerializeField] private TaskScript npc1Script;



    void Update()
    {
        //Movement 
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

        //Tasks
        if (playerInsideTrigger == true && Input.GetKeyDown(KeyCode.T))
        {
            if (tempNpc.tag == "NPC1")
            {
                Debug.Log("NPC1 Task started");
                npc1Script.TaskStart();
            }
        }
    }


    public void OnTriggerEnter(Collider other)
    {

        print(other.gameObject.tag);
        if (other.gameObject.tag == "NPC1")
        {
            tempNpc = other.gameObject;
            playerInsideTrigger = true;
            pressT.gameObject.SetActive(true);
        }

    }

    //When character leaves the collider, TaskScript can't be triggered.
    public void OnTriggerExit(Collider other)
    {
        pressT.gameObject.SetActive(false);
        playerInsideTrigger = false;
        tempNpc = null;
    }


    //SPARE CODE I WAS USING TO TRY AND PUSH AN OBJECT - WILL DELETE EVENTUALLY
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
}
