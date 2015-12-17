using UnityEngine;
using System.Collections;

public class Actor : MonoBehaviour {

    PlayerMovement myMovementController;

    bool inWater = false;
    LayerMask waterLayer = 4;
    Rigidbody rb;
    public float buoyancy = 12.5f;

    // Use this for initialization
    protected virtual void Start()
    {
        myMovementController = new PlayerMovement(this);
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        myMovementController.Update();
    }

    protected virtual void FixedUpdate()
    {
        if (inWater == true)
        {
            Vector3 force = transform.up * buoyancy;
            rb.AddForce(force, ForceMode.Acceleration);
        }
    }

    protected virtual void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.layer == waterLayer && inWater == false)
        {
            rb.drag = 0.5f;
            inWater = true;
        }
    }

    protected virtual void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.layer == waterLayer && inWater == true)
        {
            rb.drag = 0.003f;
            inWater = false;
        }
    }
}
