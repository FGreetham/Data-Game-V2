using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerBody;

    public float mouseX = 0f;
    public float mouseY = 0f;

    public float sensitivity = 5f;

    public float rotationX = 0f;
   /* public float minX = -90f;
    public float maxX = 90f; */

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    void Update()
    {
       
        //The below lines of code make the camera work - the mouseX turns in the right direction at the correct speed. 
        mouseX = Input.GetAxis("Mouse X") * sensitivity;
        mouseY -= Input.GetAxis("Mouse Y") * sensitivity;

        rotationX -= mouseY;
        mouseY = Mathf.Clamp(mouseY, -90f, 90f);
        transform.localEulerAngles = new Vector3(mouseY, 0, 0);

        playerBody.Rotate(Vector3.up * mouseX);

    }

    // Update is called once per frame
    /*void FixedUpdate()
    {
        // For Time.deltaTime - sensitivity setting needs to be way up. 200f was working better.
         mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
         mouseY -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        
        rotationX -= mouseY;
        mouseY = Mathf.Clamp(mouseY, -90f, 90f);
        transform.localEulerAngles = new Vector3(mouseY, 0, 0);

        playerBody.Rotate(Vector3.up * mouseX);

    } */



}
