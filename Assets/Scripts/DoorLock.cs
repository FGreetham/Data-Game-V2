using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DoorLock : Interactable
{
    //References and Variables
    [SerializeField] private CameraController cameraControls;
    [SerializeField] private float rotation;
    [SerializeField] private float targetRotation;
    public bool doorClosed;
    public bool doorLocked;
    public int attempts;

    //GUI variables
    public GameObject onScreen;
    public GameObject lockDoor;

    //Password GUI Variables
    public GameObject successMsg;
    public GameObject inputField;
    public GameObject tryAgain;
    public GameObject giveUp;

    public override void OnPlayerInteract()
    {
        if (DataManagerScript.instance.doorClosed == false && tag == "Door")
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
    void Update()
    {
       if (DataManagerScript.instance.doorClosed == false)
        { /*
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, raycastRange) && hit.collider.gameObject.tag == "Door")
                {
                    transform.localEulerAngles = new Vector3(-90, 0, rotation);
                    rotation = Mathf.Lerp(rotation, targetRotation, Time.deltaTime);

                    if (DataManagerScript.instance.doorClosed == false)
                    {
                        //Instructions to move the door GUI
                        StartCoroutine("Instructions");
                    }

                }
            } */

            //Move door back and forth - shift opens it again.
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
        if (other.tag == "Trigger")
        {
            DataManagerScript.instance.doorClosed = true;
            cameraControls.enabled = false;
            lockDoor.SetActive(true);
        }
    }

    //GUI to put in password to lock the door
    public void Password()
    {
        if (inputField.GetComponent<TMP_InputField>().text == "1111")
        {
            DataManagerScript.instance.doorLocked = true;
            cameraControls.enabled = true;
            lockDoor.SetActive(false);
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
        //Might need a little bit of tweaking to be sleaker
    }

    IEnumerator SuccessMsg()
    {
        successMsg.SetActive(true);
        yield return new WaitForSeconds(2);
        successMsg.SetActive(false);
    }

    //Start the variables so the door will close on first click.
    void Start()
    {   
        DataManagerScript.instance.doorLocked = false;
        DataManagerScript.instance.doorClosed = false;
        targetRotation = 190f;
        rotation = 40f;
    }

}

