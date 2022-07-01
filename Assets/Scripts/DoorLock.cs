using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DoorLock : MonoBehaviour
{
    //Variables to Close the Door
    RaycastHit hit;
    [SerializeField] private float raycastRange = 7;
    //[SerializeField] private PlayerController playerScript; > If Raycast could be in one centralised script

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

    void Update()
    {
        if (doorClosed == false)
        {
            if (Input.GetMouseButton(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, raycastRange) && hit.collider.gameObject.tag == "Door")
                {
                    transform.localEulerAngles = new Vector3(-90, 0, rotation);
                    rotation = Mathf.Lerp(rotation, targetRotation, Time.deltaTime);

                    if (doorClosed == false)
                    {
                        //Instructions to move the door GUI
                        StartCoroutine("Instructions");
                    }

                }
            }
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
            //Debug.Log(other.GetComponent<Collider>().name);
            doorClosed = true;
            Debug.Log("Door can be locked");
            cameraControls.enabled = false;
            lockDoor.SetActive(true);
        }
    }

    //GUI to put in password to lock the door
    public void Password()
    {
        if (inputField.GetComponent<TMP_InputField>().text == "1111")
        {
            doorLocked = true;
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
            attempts++;
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
            doorClosed = false;
        }
    }

    //Coroutines for GUI
    IEnumerator Instructions()
    {
        onScreen.SetActive(true);
        yield return new WaitForSeconds(5);
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
        doorLocked = false;
        doorClosed = false;
        targetRotation = 190f;
        rotation = 40f;
    }

}

