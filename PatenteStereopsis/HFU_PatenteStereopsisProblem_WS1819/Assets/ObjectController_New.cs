using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController_New : MonoBehaviour {


    // Nah und FernPunkt
    // TopDownCircle
    [Range(2, 30)]
    public float fernObjektScale;
    private GameObject fernObjektCircle;

    [Range(2, 30)]
    public float nahObjektScale;
    private GameObject nahObjektCircle;



    public float circleObjektScaleFaktorNah = 2f;
    private GameObject circlePlaneNahPunktObjekt;

    public float circleObjektScaleFaktorFern = 2f;
    private GameObject circlePlaneFernPunktObjekt;


    //CirclePlanObjects
    private GameObject circlePlaneParent;
    private GameObject playerVRCamera;


    //EyeCones
    private GameObject eyeConeParent;
    private GameObject leftEye;
    private GameObject rightEye;


    private void Awake()
    {
        //Setze EyeCone
        eyeConeParent = GameObject.Find("EyeConeParent");
        leftEye = GameObject.Find("LeftEye");
        rightEye = GameObject.Find("RightEye");

        //Setze Nah und FernObjekt
        circlePlaneNahPunktObjekt = GameObject.Find("CirclePlaneNahObjekt");
        circlePlaneFernPunktObjekt = GameObject.Find("CirclePlaneFernObjekt");

        //Get User Camera
        playerVRCamera = GameObject.Find("Camera");

        //Circles Around
        nahObjektCircle = GameObject.Find("NahObjektCircle");
        fernObjektCircle = GameObject.Find("FernObjektCircle");


        circlePlaneParent = GameObject.Find("CircleParent");
        //circlePlaneFernPunkt = GameObject.Find("CirclePlaneFernObjekt");
        //circlePlaneNahPunkt = GameObject.Find("CirclePlaneNahObjekt");
    }

    // Use this for initialization
    void Start () {
        fernObjektScale = 2;
        nahObjektScale = 2;

        circleObjektScaleFaktorNah = 0.4f;
        circleObjektScaleFaktorFern = 0.5f;

    }
	
	// Update is called once per frame
	void Update () {

        //Set CircleScale
        CircleScale(fernObjektCircle, fernObjektScale);
        CircleScale(nahObjektCircle, nahObjektScale);

        //
        //SetVRCameraOrientaionToObjectParent(playerVRCamera);
        setObjectAsRotationParent(circlePlaneParent.transform, playerVRCamera.transform);

        // die Position kann über den Scale gesetzt werden
        setCircleObjectPositions(circlePlaneNahPunktObjekt, nahObjektScale);
        setCircleObjectPositions(circlePlaneFernPunktObjekt, fernObjektScale);

        //Der Scale des Objekts wird über den Faktor gesetzt
        setCircleObjectScale(circlePlaneNahPunktObjekt, circleObjektScaleFaktorNah);
        setCircleObjectScale(circlePlaneFernPunktObjekt, circleObjektScaleFaktorFern);

    }


    public void setObjectAsRotationParent(Transform childObject, Transform parentObject)
    {
        //childObject.localRotation = parentObject.rotation;
        //childObject.RotateAround(parentObject,);
        //childObject.transform.rotation = parentObject.transform.rotation;
        //childObject.LookAt(parentObject);
    }

    /*
    //Holt VR-Camera Orientation und setzt sie auf den ObjektParent
    public void SetVRCameraOrientaionToObjectParent(Transform camera)
    {
        circlePlaneParent.transform.RotateAround = camera.rotation;
    }
    */



    public void CircleScale(GameObject objectToScale ,float scale)
    {
        objectToScale.transform.localScale = new Vector3(scale / 60, scale / 60, scale / 60);
    }



    public void setCircleObjectPositions(GameObject circlePlaneObject, float position)
    {
        var tp =  transform.position;
        circlePlaneObject.transform.position = new Vector3(tp.x, tp.y, tp.z + position);
        //print(circlePlaneObject.transform.position.z);
    }



    public void setCircleObjectScale(GameObject circlePlaneObject, float scale)
    {
        float distanceFaktor = circlePlaneObject.transform.position.z;
        var ts = transform.localScale;

        //circlePlaneObject.transform.localScale = new Vector3(scale / 60, scale / 60, scale / 60);
        circlePlaneObject.transform.localScale = new Vector3(ts.x * distanceFaktor * scale, ts.y* 0.001f , ts.z* distanceFaktor * scale);
        //print(circlePlaneObject.transform.position.z);
    }
}
