using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //Character movement variables
    [Header("Movement")]
    [SerializeField] private CharacterController controller;
    public float speed = 2.0f;
    private float gravity = -9.8f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask; 
    private float groundDistance = 0.4f;
    private bool isGrounded;
    private Vector3 velocity;


    //NPC Task related variables
    [Header("NPC Task Variables")]
    private bool playerInsideTrigger;
    [SerializeField] private GameObject npc;
    [SerializeField] private TextMeshProUGUI pressT;
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
            if (npc.tag == "NPC1")
            {
                npc1Script.TaskStart();
            }
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NPC1")
        {
            npc = other.gameObject;
            playerInsideTrigger = true;
            pressT.gameObject.SetActive(true);
        }

        //Autosave the player data at this point
        DataManagerScript.instance.SaveData();
    }

    //When character leaves the collider, TaskScript can't be triggered.
    public void OnTriggerExit(Collider other)
    {
        pressT.gameObject.SetActive(false);
        playerInsideTrigger = false;
        npc = null;
    }


}
