using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 10;
    public float turnSpeed = 5;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Movement(v);
        Rotation(h);
    }

    //movement of the player
    void Movement(float v)
    {
        Vector3 movement = new Vector3(0.0f, 0.0f, v);
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    void Rotation(float h)
    {
        Vector3 rotation = new Vector3(0.0f, h, 0.0f);
        transform.Rotate(rotation * turnSpeed * Time.deltaTime);
    }
}
