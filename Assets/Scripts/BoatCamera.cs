using UnityEngine;
using System.Collections;

public class BoatCamera : MonoBehaviour {

    public GameObject cameraAxis;
    public GameObject crossHair;
    private Vector3 cameraPos;
    private Quaternion tempPos;
    private Transform tempTransform;
    public float offset;
    public LayerMask layerMask;

    public GameObject[] walls;

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
        RaycastHit hit;
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.position + Camera.main.transform.localToWorldMatrix.MultiplyVector(Vector3.back * 2), Color.blue);
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.position + Camera.main.transform.localToWorldMatrix.MultiplyVector(Vector3.back * 2), out hit, 2f, layerMask))
        {
            Debug.DrawRay(hit.point, Vector3.up * 30, Color.yellow);
            Camera.main.transform.position = hit.point + Camera.main.transform.localToWorldMatrix.MultiplyVector(Vector3.forward * 2);
        }
        Camera.main.transform.position = new Vector3(Mathf.Clamp(Camera.main.transform.position.x, walls[3].transform.position.x + 1, walls[1].transform.position.x - 1),
                                                                 Camera.main.transform.position.y, 
                                                     Mathf.Clamp(Camera.main.transform.position.z, walls[2].transform.position.z + 1, walls[0].transform.position.z - 1));
    }

}
