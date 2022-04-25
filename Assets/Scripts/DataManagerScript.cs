using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManagerScript : MonoBehaviour
{
    public static DataManagerScript instance;

    [SerializeField] private CatFound catScript;
    public bool task1Complete;
    public bool taskRunning;

    private int allCollectables;
    private int allInteractables;
    public int[] taskCollectables = { 1 , 2, 3 };
    public int[] taskInteractables = { 1, 2, 3 };

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


    // Update is called once per frame
    void Update()
    {
        //Task 1 - Collect the cat
        if (catScript.catCollected)
        {
            taskRunning = false;
            task1Complete = true;
        }

        if (gameObject.tag == "Collectable") //Should this reference if tagged object destroyed,
                                             //or should this be on a different script and reference the allCollectables from there?
        {
            allCollectables++;
            if(taskRunning == true)
            {

            }
        }
        
    }
}
