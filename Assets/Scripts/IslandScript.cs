using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IslandScript : MonoBehaviour {


    public List<GameObject> Ducks;
    public Object storedItem;
    public bool playerClose;

    // Use this for initialization
    void Start ()
    {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void RemoveDuck(GameObject Duck)
    {
        Ducks.Remove(Duck);
    }
}
