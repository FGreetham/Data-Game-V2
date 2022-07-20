using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Camera movement variables
    [SerializeField] private Transform playerBody;
    private float mouseX = 0f;
    private float mouseY = 0f;
    private float sensitivity = 5f;
    private float rotationX = 0f;

    //Raycast variables
    RaycastHit hit;
    private float raycastRange = 7;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    void Update()
    {

        mouseX = Input.GetAxis("Mouse X") * sensitivity;
        mouseY -= Input.GetAxis("Mouse Y") * sensitivity;

        rotationX -= mouseY;
        mouseY = Mathf.Clamp(mouseY, -90f, 90f);
        transform.localEulerAngles = new Vector3(mouseY, 0, 0);

        playerBody.Rotate(Vector3.up * mouseX);

        //Raycast interaction 
        if (Input.GetMouseButtonDown(0))
        {
            InteractionCheck();
        }
        
    }

    //Raycast code which can be used for objects which can be collected or interacted with
    public void InteractionCheck()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, raycastRange))
        {
            var interactableComponent = hit.collider.GetComponent<Interactable>();
            if (interactableComponent != null)
            {
                interactableComponent.OnPlayerInteract();
            }
        }
    }
}
