using UnityEngine;

// Put this script on the cat GameObject
public class Cat : Collectable
{
    public override void OnPlayerCollect()
    {
        // The DataManager is a Singleton (it has a static instance), so we can reference it directly like this
        DataManagerScript.instance.catsFound++;
        gameObject.SetActive(false);
    }
}