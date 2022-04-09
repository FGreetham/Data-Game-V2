using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFound : MonoBehaviour
{
    public bool catCollected;

    private void OnTriggerEnter(Collider other)
    {
        catCollected = true;
        Debug.Log("Cat Found and Task 1 Complete");
        gameObject.SetActive(false);
    }
}
