using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManagerScript : MonoBehaviour
{
    public static DataManagerScript instance; 
    /* should this be the script or the gameObject it's attached to? 
    Might need to update and specify game object */

    private void Awake()
    {
        if (instance != null)
        {
           Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        Debug.Log("Awake: " + this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
