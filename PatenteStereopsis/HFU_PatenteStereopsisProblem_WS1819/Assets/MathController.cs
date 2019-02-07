using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathController : MonoBehaviour {

    private float nahObjectDistance; 
    private float fernObjectDistance;


    private void Awake()
    {
        nahObjectDistance = this.GetComponent<ObjectController_New>().nahObjektScale;
        fernObjectDistance = this.GetComponent<ObjectController_New>().fernObjektScale;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        print(nahObjectDistance +" . " + fernObjectDistance);
	}
}
