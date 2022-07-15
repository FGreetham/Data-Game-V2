using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //Character movement variables
    [Header("Movement")]
    public CharacterController controller;
    public float speed = 2.0f;
    private float gravity = -9.8f;
    public Transform groundCheck;
    public LayerMask groundMask; 
    private float groundDistance = 0.4f;
    bool isGrounded;
    Vector3 velocity;

    //Raycast variables
    RaycastHit hit;
    private float raycastRange = 7;

    //NPC Task related variables
    [Header("NPC Task Variables")]
    private bool playerInsideTrigger;
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

        //Raycast interaction 
        if(Input.GetMouseButtonDown(0))
        {
            InteractionCheck();
        }

        //Tasks
        if (playerInsideTrigger == true && Input.GetKeyDown(KeyCode.T))
        {
            if (tempNpc.tag == "NPC1")
            {
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

    //Raycast code which can be used for objects which can be collected or interacted with
    void InteractionCheck()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, raycastRange))
        {
            var interactableComponent = hit.transform.GetComponent<Interactable>();
            if(interactableComponent != null)
            {
               interactableComponent.OnPlayerInteract();
            }
        }      
    }

}
