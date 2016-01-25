using UnityEngine;
using System.Collections;

public class RendererFix : MonoBehaviour {

    public int queueValue = 1;

	// Use this for initialization
	void Start () {
        Renderer rend = GetComponent<Renderer>();
        rend.material.renderQueue = queueValue;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
