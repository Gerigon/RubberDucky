using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {

    PlayerMovement myMovementController;
	// Use this for initialization
	protected virtual void Start ()
    {
        myMovementController = new PlayerMovement(this);
	}
	
	// Update is called once per frame
	protected virtual void Update ()
    {
        myMovementController.Update();
    }
}
