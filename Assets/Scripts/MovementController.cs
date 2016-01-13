using UnityEngine;
using System.Collections;

public class MovementController {

    public float moveSpeed = 10;
    public float turnSpeed = 40;

    private Actor _owner;

	// Use this for initialization
    public MovementController(Actor owner)
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
    }

    public void Buoyancy()
    {
        
        RaycastHit hit;
        if (Physics.Raycast(_owner.transform.position,Vector3.down,out hit))
        {
            Debug.Log("oyoyoyoyo");
            _owner.transform.position = hit.transform.position;
            Debug.DrawRay(_owner.transform.position, Vector3.up * 10, Color.green, 10f);
        }
        //_owner.transform.position = 
    }

    //movement of the player
    public void Movement(float v)
    {
        Vector3 movement = new Vector3(0.0f, 0.0f, v);
        _owner.transform.Translate(-movement * moveSpeed * Time.deltaTime,Space.Self);
    }

    public void Rotation(float h)
    {
        Vector3 rotation = new Vector3(0.0f, h, 0.0f);
        _owner.transform.Rotate(rotation * turnSpeed * Time.deltaTime);
    }
}
