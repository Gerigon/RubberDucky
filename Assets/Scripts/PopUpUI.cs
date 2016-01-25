using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopUpUI : MonoBehaviour {

    public Camera boatCamera;
    public Canvas thisCanvas;

	// Use this for initialization
	void Start ()
    {
        boatCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        thisCanvas = transform.GetComponent<Canvas>();
        thisCanvas.worldCamera = boatCamera;

        thisCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    public void EnableCanvas()
    {
        thisCanvas.enabled = true;
    }

    public void DisableCanvas()
    {
        thisCanvas.enabled = false;
    }

    public void LoadImage(GameObject thisGameObject)
    {
        switch(thisGameObject.name)
        {
            case "Super Hull";
        }
    }
}
