using UnityEngine;
using System.Collections;

public class PlayerMovement {

    public float moveSpeed = 10;
    public float turnSpeed = 40;

    private Actor _owner;

	// Use this for initialization
    public PlayerMovement(Actor owner)
    {
        if (owner != null)
        {
            this._owner = owner;
        }
        else
        {
            Debug.LogError("No actor attached");
        }
    }

    void Start ()
    {
	
	}
	
	// Update is called once per frame
	public void Update ()
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
        _owner.transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    void Rotation(float h)
    {
        Vector3 rotation = new Vector3(0.0f, h, 0.0f);
        _owner.transform.Rotate(rotation * turnSpeed * Time.deltaTime);
    }
}
