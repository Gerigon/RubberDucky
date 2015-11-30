using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public GameObject cannon;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetAxis("Horizontal")!= 0)
        {
            cannon.transform.Rotate(Vector3.up, Input.GetAxis("Horizontal"),Space.World);
        }
	}
}
