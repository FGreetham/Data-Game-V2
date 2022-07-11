using UnityEngine;

// You cannot create an instance of an abstract class - you can only create instances of classes that inherit from it
public abstract class Collectable : MonoBehaviour
{
    // An abstract method is one that must be overridden in subclasses
    public abstract void OnPlayerCollect();
}