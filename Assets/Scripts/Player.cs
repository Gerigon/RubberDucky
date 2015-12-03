using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public GameObject cannonHolder;
    public GameObject cannonBall;
    public GameObject crossHair;

    private GameObject cannon;

    private Vector3 movement;

    private float fireTime = 0;
    private float fireRate = 2;
    public float cannonForce;



    void Start()
    {
        cannon = cannonHolder.transform.GetChild(0).transform.gameObject;
    }
    void Update()
    {
        fireTime += Time.deltaTime;
        PlayerInput();

        cannonHolder.transform.Rotate(Vector3.up, movement.x, Space.World);

    }
    void PlayerInput()
    {
        movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetAxis("Fire1") > 0 && (fireTime > fireRate))
        {
            fireTime = 0;
            Fire();
        }
    }
    void Fire()
    {
        GameObject cBall = Instantiate(cannonBall, cannon.transform.position + cannon.transform.localToWorldMatrix.MultiplyVector(transform.up), Quaternion.identity) as GameObject;
        cBall.GetComponent<Rigidbody>().velocity = BallisticVel(crossHair.transform, 30);
        Destroy(cBall, 10);
    }
    Vector3 CalculateVelocity()
    {
        Vector3 dir = cannon.transform.position - (cannonHolder.transform.position).normalized * cannonForce;
        return dir;
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
}
