using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Door : MonoBehaviour
{
    //This Door class is not inheriting from the Interactable class - because the door moves smoothly when holding the button down instead of individual clicks.
    //This causes some issues with other items if I change this at the controller level in "Camera Controller".

    //References and Variables
    private CameraController cameraControls;
    private float rotation;
    private float targetRotation;
    private float raycastRange = 7f;
    RaycastHit hit;

    //GUI variables
    public GameObject onScreen;
    public GameObject lockDoor;

    //Password GUI Variables
    public GameObject successMsg;
    public GameObject inputField;
    public GameObject tryAgain;
    public GameObject giveUp;


    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, raycastRange))
            {
                if (DataManagerScript.instance.doorClosed == false && hit.collider.tag == "Door")
                {
                    transform.localEulerAngles = new Vector3(-90, 0, rotation);
                    rotation = Mathf.Lerp(rotation, targetRotation, Time.deltaTime);

                    if (DataManagerScript.instance.doorClosed == false)
                    {
                        //Instructions to move the door GUI
                        StartCoroutine("Instructions");
                    }
                }
            }
        }
    

    if (DataManagerScript.instance.doorClosed == false)
        { 
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                targetRotation = 40f;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                targetRotation = 185f;
            }
        } 
    }

    //Lock door command
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trigger" && DataManagerScript.instance.doorClosed == false)
        {
            DataManagerScript.instance.doorClosed = true;
            cameraControls.enabled = false;
            lockDoor.SetActive(true);
        }
    }

    //GUI to put in password to lock the door
    public void Password()
    {
        if (inputField.GetComponent<TMP_InputField>().text == "Garden247")
        {
            lockDoor.SetActive(false);
            DataManagerScript.instance.doorLocked = true;
            DataManagerScript.instance.doorAttempts++;
            cameraControls.enabled = true;
            StartCoroutine("SuccessMsg");
            this.enabled = false;
        }
        else
        {
            lockDoor.SetActive(true);
            tryAgain.GetComponent<TMP_Text>().text = "Try again";
            giveUp.SetActive(true);
            DataManagerScript.instance.doorAttempts++;
        }
    }

    public void GiveUp()
    {
        cameraControls.enabled = true;
        lockDoor.SetActive(false);
    }

    //In case it fails or bounces back
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Trigger")
        {
            DataManagerScript.instance.doorClosed = false;
        }
    }

    //Coroutines for GUI
    IEnumerator Instructions()
    {
        onScreen.SetActive(true);
        yield return new WaitForSeconds(2);
        onScreen.SetActive(false);
    }

    IEnumerator SuccessMsg()
    {
        successMsg.SetActive(true);
        yield return new WaitForSeconds(2);
        successMsg.SetActive(false);
        this.enabled = false;
    }

    //Start the variables so the door will close on first click.
    void Start()
    {
        cameraControls = FindObjectOfType<CameraController>();
        DataManagerScript.instance.doorLocked = false;
        DataManagerScript.instance.doorClosed = false;
        targetRotation = 190f;
        rotation = 40f;
    }

}

