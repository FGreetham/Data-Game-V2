using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public GameObject exitMenu;
    [SerializeField] private CameraController cameraControls;
    public CharacterController controller;

    public void OnTriggerEnter()
    {
        exitMenu.SetActive(true);
        cameraControls.enabled = false;

       // controller.enabled = false;
    }

    public void Continue()
    {
        exitMenu.SetActive(false);
        cameraControls.enabled = true;
      //  controller.enabled = true;
    }

    public void SaveAndExit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
