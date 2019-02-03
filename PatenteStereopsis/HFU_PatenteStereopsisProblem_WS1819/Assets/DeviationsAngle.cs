using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviationsAngle : MonoBehaviour {

    public GameObject objectOne;
    public GameObject objectTwo;

    public Camera vrCam;

    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        // b
        float objectdistance = Vector3.Distance(objectOne.transform.position, objectTwo.transform.position);
        // a
        float distanceToZero = Vector3.Distance(objectOne.transform.position, vrCam.transform.position);
        // n 
        //float eyeDist = 0.065f;
        float eyeDist = 5;


        float tan = objectdistance + distanceToZero / eyeDist;


        float angle = Mathf.Rad2Deg * Mathf.Atan(tan);

        print(angle);

        //print(objectdistance + " : " + distanceToZero + " : " + angle);

        //float hypotenuse = Mathf.Sqrt((objectdistance + distanceToZero)* objectdistance + distanceToZero) + (eyeDist) * (eyeDist);

        //print(distanceToZero + " : " +  angle + " : " + eyeDist);
        ////radius = ObjectSpawnerONE.GetComponent<Vertices>().GetRadius();
        //print(ObjectSpawnerONE.GetComponent<Vertices>().GetRadius());
        //print(ObjectSpawnerTWO.GetComponent<Vertices>().GetRadius());
	}
}
