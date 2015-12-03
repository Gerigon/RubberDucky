using UnityEngine;
using System.Collections;

public class BoatCamera : MonoBehaviour {

    public GameObject cannonHolder;
    private Vector3 cameraPos;

    public float camDistance = 10f;
    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        cameraPos = cannonHolder.transform.position + cannonHolder.transform.localToWorldMatrix.MultiplyVector(Vector3.back) * camDistance;
        Camera.main.transform.position = cameraPos;
	}
    void LateUpdate()
    {
        Camera.main.transform.LookAt(cannonHolder.transform);
    }

}
