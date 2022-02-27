using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerBody;

    public float sensitivity = 5f;

    public float xRotation = 90f;
    public float minX = -60f;
    public float maxX = 60f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*The 4 lines of code make the camera work - the mouse turns in the right direction
         at the correct speed. But it doesn't clamp. 
        Also Time.deltaTime makes it very slow to move, even when increasing sensitivity 
        and it's hard to control the mouse. Smoother without it.*/
        float mouseX = Input.GetAxis("Mouse X") * sensitivity; // * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity; // * Time.deltaTime;

        playerBody.Rotate(Vector3.up * mouseX);
        transform.Rotate(Vector3.left * mouseY);

        /*THE CAMERA DOES NOT CLAMP EVEN WHEN I USE THE BELOW CODE. 
          IT EITHER SHAKES, OR LOOKS AT THE GROUND */
        /* xRotation -= mouseY;
          xRotation = Mathf.Clamp(mouseX, minX, maxX); 
          transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
          transform.Rotate(Vector3.right * mouseY); */

    }
}
