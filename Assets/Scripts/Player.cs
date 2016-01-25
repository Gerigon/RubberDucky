using UnityEngine;
using System.Collections;

public class Player : Actor
{

    public GameObject cannonHolder;
    public GameObject cannonBall;
    public GameObject crossHair;
    public GameObject sea;

    private GameObject cannon;

    private Vector3 movement;
    private BoatCamera boatCamera;

    private float fireTime = 0;
    private float fireRate = 2;

    public float aimSensivity;

    float mouseY;





    protected override void Start()
    {
        boatCamera = GetComponent<BoatCamera>();
        base.Start();
        health = 50;
        cannon = cannonHolder.transform.GetChild(0).transform.gameObject;
    }
    protected override void Update()
    {
        base.Update();
        fireTime += Time.deltaTime;
        PlayerInput();


    }
    void PlayerInput()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        myMovementController.Movement(movement.y,true);
        myMovementController.Rotation(movement.x);

        /*
        if (movement == Vector3.zero)
        {
        old stuff
        }
        */

        if (Input.GetAxis("Fire1") > 0 && (fireTime > fireRate))
        {
            fireTime = 0;
            Fire();
        }


        //cannonHolder.transform.LookAt(crossHair.transform);

        if (Input.GetAxis("Mouse X")!= 0)
        {
            cannonHolder.transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * aimSensivity, Space.World);
        }

        if (Input.GetAxis("Mouse Y") != 0)
        {
            mouseY = Input.GetAxis("Mouse Y");
            float distance = Vector3.Distance(crossHair.transform.position, cannonHolder.transform.position);
            if (distance <= 6f)
            {
                mouseY = Mathf.Clamp(mouseY, 0, 1000);
            }
            if (distance > 50)
            {
                mouseY = Mathf.Clamp(mouseY, -1000, 0);
            }

            boatCamera.offset = distance;
            crossHair.transform.Translate(new Vector3(0,0, mouseY), Space.Self);
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddForce(Vector3.back * 20f);
        }
    }
    void Fire()
    {
        GameObject cBall = Instantiate(cannonBall, cannon.transform.position + cannon.transform.localToWorldMatrix.MultiplyVector(transform.up), Quaternion.identity) as GameObject;
        cBall.GetComponent<Rigidbody>().velocity = BallisticVel(crossHair.transform, 30);
        Destroy(cBall, 10);
    }

    Vector3 BallisticVel(Transform target, float angle)
    {
        Vector3 dir = target.position - cannon.transform.position + cannon.transform.localToWorldMatrix.MultiplyVector(transform.up); // get target direction 
        float h = dir.y; // get height difference 
        dir.y = 0; // retain only the horizontal direction 
        float dist = dir.magnitude; // get horizontal distance 
        float a = angle * Mathf.Deg2Rad; // convert angle to radians 
        dir.y = dist * Mathf.Tan(a); // set dir to the elevation angle 
        dist += h / Mathf.Tan(a); // correct for small height differences 
        // calculate the velocity magnitude 
        float vel = Mathf.Sqrt(dist * Physics.gravity.magnitude / Mathf.Sin(2 * a)); return vel * dir.normalized;
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log("pushing");
            Vector3 direction = (transform.position - other.transform.position).normalized;
            rb.AddForce(direction * 10, ForceMode.VelocityChange);
        }
    }
}
