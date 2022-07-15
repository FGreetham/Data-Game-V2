using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //To be overridden in subclasses
    public abstract void OnPlayerInteract();
}
