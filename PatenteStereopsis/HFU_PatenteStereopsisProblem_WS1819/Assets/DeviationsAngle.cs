using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviationsAngle : MonoBehaviour {

    public GameObject uiController;

    public GameObject FernPunkt;
    private Transform fernPunktCirclePlane;

    public GameObject NahPunkt;
    private Transform nahPunktCirclePlane;

    //public Camera vrCam;
    public Transform vrCAMTrans;

    [Range(10,100)]
    public float deviationAngle;

    [Range(0.04f, 0.07f)]
    public float eyeDistance;
    private float halfEyeDist;

    private float NahPunktDistanceToZero;

    // Use this for initialization
    void Start () {
        //objectOne = GameObject.Find("FernPunkt").GetComponentInChildren<CirclePlane>().
        eyeDistance = 0.065f;
     }
	
	// Update is called once per frame
	void Update () {

        halfEyeDist = eyeDistance / 2;

        deviationAngle = uiController.GetComponent<UI_ControllerScript>().getUIDevAngleSlider();


        fernPunktCirclePlane = FernPunkt.gameObject.transform.GetChild(0);
        nahPunktCirclePlane = NahPunkt.gameObject.transform.GetChild(0);


        float fernPunktDistanceToZero = distanceToZero(vrCAMTrans, fernPunktCirclePlane);
        float nahPunktDistanceToZero = distanceToZero(vrCAMTrans, nahPunktCirclePlane);

        float FernpunktAngle = Mathf.Atan(fernPunktDistanceToZero  / halfEyeDist);


        NahPunktDistanceToZero = Mathf.Tan(FernpunktAngle -deviationAngle) *  halfEyeDist;

        //print(NahPunktDistanceToZero);

        //deviationAngle = FernpunktAngle - NahPunktAngle;






        /*
        // b
        float objectdistance = Vector3.Distance(fernPunktCirclePlane.transform.position, nahPunktCirclePlane.transform.position);
        // a
        float distanceToZero = Vector3.Distance(fernPunktCirclePlane.transform.position, vrCam.transform.position);
        // n 
        float eyeDist = 0.065f;
        //float eyeDist = 5;


        float tan = objectdistance + distanceToZero / eyeDist;


        float angle = Mathf.Rad2Deg * Mathf.Atan(tan);

        print(angle);

        //print(objectdistance + " : " + distanceToZero + " : " + angle);

        //float hypotenuse = Mathf.Sqrt((objectdistance + distanceToZero)* objectdistance + distanceToZero) + (eyeDist) * (eyeDist);

        //print(distanceToZero + " : " +  angle + " : " + eyeDist);
        ////radius = ObjectSpawnerONE.GetComponent<Vertices>().GetRadius();
        //print(ObjectSpawnerONE.GetComponent<Vertices>().GetRadius());
        //print(ObjectSpawnerTWO.GetComponent<Vertices>().GetRadius());
        */
    }

    public float distanceToZero(Transform zeroPoint, Transform objectPoint)
    {
        return Vector3.Distance(zeroPoint.transform.position, objectPoint.transform.position); ;
    }


    public float getNPdistancetoZero()
    {
        return NahPunktDistanceToZero;
    }
}
