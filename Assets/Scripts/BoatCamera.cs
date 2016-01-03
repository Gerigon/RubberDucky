using UnityEngine;
using System.Collections;

public class BoatCamera : MonoBehaviour {

    public GameObject cameraAxis;
    public GameObject crossHair;
    private Vector3 cameraPos;
    private Quaternion tempPos;
    private Transform tempTransform;
    public float offset;

    public float camDistance = 10f;
    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        tempPos = cameraAxis.transform.parent.transform.rotation;
        tempPos *= Quaternion.Euler(new Vector3(offset, 0, 0));
        cameraAxis.transform.rotation = tempPos;
        cameraPos = cameraAxis.transform.position + cameraAxis.transform.localToWorldMatrix.MultiplyVector(Vector3.back) * camDistance;
        Camera.main.transform.position = cameraPos;
	}
    void LateUpdate()
    {
        Camera.main.transform.LookAt((crossHair.transform.position - cameraAxis.transform.position) * 0.5f + cameraAxis.transform.position);
    }

}
