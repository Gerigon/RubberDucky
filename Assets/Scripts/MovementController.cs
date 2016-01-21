using UnityEngine;
using System.Collections;

public class MovementController {

    public float moveSpeed = 10;
    public float turnSpeed = 60;

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

        if (_owner.name == "Boat")
        {
            _owner.rb.velocity = new Vector3(Mathf.Clamp(_owner.rb.velocity.x, -35f, 35f), _owner.rb.velocity.y, Mathf.Clamp(_owner.rb.velocity.z, -35f, 35f));
            
            Vector3 localVel = _owner.transform.InverseTransformDirection(_owner.rb.velocity);
            localVel.x *= 0.95f;
            _owner.rb.velocity = _owner.transform.TransformDirection(localVel);

            /*
            old stuff
            //_owner.rb.velocity = new Vector3(_owner.rb.velocity.x * 0.995f, _owner.rb.velocity.y, _owner.rb.velocity.z * 0.995f);
            //Debug.Log(_owner.transform.InverseTransformDirection(_owner.rb.velocity));
            //Debug.Log(Mathf.Abs(Vector3.Angle(_owner.rb.velocity, -_owner.transform.forward))/180);
            */
        }
    }
    //movement of the player
    public void Movement(float v)
    {
        Vector3 movement = new Vector3(0.0f, 0.0f, v);
        _owner.transform.Translate(-movement * moveSpeed * Time.deltaTime,Space.Self);
    }
    public void Movement(float v, bool force)
    {
        Vector3 movement = new Vector3(0.0f, 0.0f, v * 3);
        _owner.rb.AddRelativeForce(-movement,ForceMode.Acceleration);
        //_owner.transform.Translate(movement * moveSpeed * Time.deltaTime, Space.Self);
    }
    public void Movement(Vector3 v)
    {
        Vector3 movement = v;
        _owner.transform.Translate(movement * moveSpeed * Time.deltaTime,Space.World);
        //_owner.transform.position += movement;
    }


    public void Rotation(float h)
    {
        Vector3 rotation = new Vector3(0.0f, h, 0.0f);
        _owner.transform.Rotate(rotation * turnSpeed * Time.deltaTime);
    }
}
