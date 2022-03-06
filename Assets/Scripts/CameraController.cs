using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerBody;

    public float sensitivity = 5f;

    public float rotationX = 0f;
    public float minX = -90f;
    public float maxX = 90f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        /*The below lines of code make the camera work - the mouseX turns in the right direction
         at the correct speed. But it doesn't clamp. */
        float mouseX = Input.GetAxis("Mouse X") * sensitivity; // * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity; // * Time.deltaTime;
        /*    Also Time.deltaTime makes it very slow to move, even when increasing sensitivity 
        and it's hard to control the mouse. Smoother without it so I've left it off for now. */


        /*THE CAMERA DOES NOT CLAMP EVEN WHEN I USE THE BELOW CODE. 
      Currently MouseY does nothing and when it does, Camera either shakes or looks at the ground */
        mouseY = Mathf.Clamp(rotationX, minX, maxX);
        transform.localRotation = Quaternion.Euler(mouseY, 0, 0);

        playerBody.Rotate(Vector3.up * mouseX);
        transform.Rotate(Vector3.left * mouseY);

     
        /* SPARE CODE ATTEMPTS
         * rotationX -= mouseY;
          rotationX = Mathf.Clamp(mouseX, minX, maxX); 
          transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        OR ransform.eulerAngles = new Vector3(mouseY, mouseX, 0); 
          transform.Rotate(Vector3.right * mouseY); */

    }
}
