using UnityEngine;
using System.Collections;

public class MovementController {

    public float moveSpeed = 10;
    public float turnSpeed = 100;

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
            if (_owner.GetComponent<BoatParts>().currentHull == Hull.StandardHull)
            {
                _owner.rb.velocity = new Vector3(Mathf.Clamp(_owner.rb.velocity.x, -35f, 35f), _owner.rb.velocity.y, Mathf.Clamp(_owner.rb.velocity.z, -35f, 35f));

                Vector3 localVel = _owner.transform.InverseTransformDirection(_owner.rb.velocity);
                localVel.x *= 0.95f;
                _owner.rb.velocity = _owner.transform.TransformDirection(localVel);
            }
            if (_owner.GetComponent<BoatParts>().currentHull == Hull.FastHull || _owner.GetComponent<BoatParts>().currentHull == Hull.SuperHull)
            {
                _owner.rb.velocity = new Vector3(Mathf.Clamp(_owner.rb.velocity.x, -45f, 45f), _owner.rb.velocity.y, Mathf.Clamp(_owner.rb.velocity.z, -45f, 45f));

                Vector3 localVel = _owner.transform.InverseTransformDirection(_owner.rb.velocity);
                localVel.x *= 0.98f;
                _owner.rb.velocity = _owner.transform.TransformDirection(localVel);
            }


            /*
            old stuff
            //_owner.rb.velocity = new Vector3(_owner.rb.velocity.x * 0.995f, _owner.rb.velocity.y, _owner.rb.velocity.z * 0.995f);
            //Debug.Log(_owner.transform.InverseTransformDirection(_owner.rb.velocity));
            //Debug.Log(Mathf.Abs(Vector3.Angle(_owner.rb.velocity, -_owner.transform.forward))/180);
            */
        }

        if (_owner.name.Contains("duck"))
        {
            Vector3 localVel = _owner.transform.InverseTransformDirection(_owner.rb.velocity);
            localVel.x *= 0.95f;
            _owner.rb.velocity = _owner.transform.TransformDirection(localVel);
        }
    }

    //Rotation & movement of the player
    public void Rotation(float h)
    {
        if (_owner.GetComponent<BoatParts>().currentHull == Hull.FastHull || _owner.GetComponent<BoatParts>().currentHull == Hull.SuperHull)
        {
            h *= 1.2f;
        }
        if (_owner.GetComponent<BoatParts>().currentHull == Hull.SturdyHull)
        {
            h *= 0.8f;
        }
        Vector3 rotation = new Vector3(0.0f, h, 0.0f);
        _owner.transform.Rotate(rotation * turnSpeed * Time.deltaTime);
    }
    public void Movement(float v, bool force)
    {
        if (_owner.GetComponent<BoatParts>().currentHull == Hull.FastHull || _owner.GetComponent<BoatParts>().currentHull == Hull.SuperHull)
        {
            v *= 1.2f;
        }
        if (_owner.GetComponent<BoatParts>().currentHull == Hull.SturdyHull)
        {
            v *= 0.8f;
        }
        Vector3 movement = new Vector3(0.0f, 0.0f, v * 3);
        _owner.rb.AddRelativeForce(-movement,ForceMode.Acceleration);
    }
    //enemy movement
    public void Movement(Vector3 v, bool force)
    {
        Vector3 movement = new Vector3(v.x, 0, v.z);
        _owner.rb.AddForce(movement * 3, ForceMode.Acceleration);
    }


    
}
