using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject pickUpMenu;
    private CameraController cameraControls;
    private CollectableItem currentCollectable;

    private void Start()
    {
        cameraControls = FindObjectOfType<CameraController>();
    }
    public void ShowPickUpMenu(CollectableItem collectable)
    {
        currentCollectable = collectable;
        pickUpMenu.gameObject.SetActive(true);
        cameraControls.enabled = false;
    }

    public void HidePickUpMenu()
    {
        pickUpMenu.gameObject.SetActive(false);
        cameraControls.enabled = true;
        currentCollectable = null;
    }

    public void OnYesButtonClicked()
    {
        currentCollectable.PickUpItem();
        HidePickUpMenu();
    }

    public void OnNoButtonClicked()
    {
        HidePickUpMenu();
    }
}
