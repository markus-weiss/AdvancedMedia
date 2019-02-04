using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController_New : MonoBehaviour {


    // Nah und FernPunkt
    // TopDownCircle
    private GameObject fernObjektCircle;
    [Range(2,30)]
    public float fernObjektScale;

    private GameObject nahObjektCircle;
    [Range(2, 30)]
    public float nahObjektScale;


    public float circleObjektScaleFaktor = 2f;
    private GameObject circlePlaneNahPunktObjekt;
    private GameObject circlePlaneFernPunktObjekt;


    //CirclePlanObjects
    private GameObject circlePlaneParent;
    private Transform playerVRCamera;





    private void Awake()
    {
        circlePlaneNahPunktObjekt = GameObject.Find("CirclePlaneNahObjekt");
        circlePlaneFernPunktObjekt = GameObject.Find("CirclePlaneFernObjekt");

        //Get User Camera
        playerVRCamera = GameObject.Find("Camera").GetComponentInChildren<Transform>();

        //Circles Around
        fernObjektCircle = GameObject.Find("FernObjektCircle");
        nahObjektCircle = GameObject.Find("NahObjektCircle");

        circlePlaneParent = GameObject.Find("CircleParent");
        //circlePlaneFernPunkt = GameObject.Find("CirclePlaneFernObjekt");
        //circlePlaneNahPunkt = GameObject.Find("CirclePlaneNahObjekt");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CircleScale(fernObjektCircle, fernObjektScale);
        CircleScale(nahObjektCircle, nahObjektScale);
        SetVRCameraOrientaionToObjectParent(playerVRCamera);

        // die Position kann über den Scale gesetzt werden
        setCircleObjectPositions(circlePlaneNahPunktObjekt, nahObjektScale);
        setCircleObjectPositions(circlePlaneFernPunktObjekt, fernObjektScale);

        //Der Scale des Objekts wird über den Faktor gesetzt
        setCircleObjectScale(circlePlaneFernPunktObjekt, circleObjektScaleFaktor);
        setCircleObjectScale(circlePlaneFernPunktObjekt, circleObjektScaleFaktor);

    }

    //Holt VR-Camera Orientation und setzt sie auf den ObjektParent
    public void SetVRCameraOrientaionToObjectParent(Transform camera)
    {
        circlePlaneParent.transform.rotation = camera.rotation;
    }

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
        var ts = transform.localScale;
        circlePlaneObject.transform.localScale = new Vector3(ts.x , ts.y , ts.z);
        //circlePlaneObject.transform.localScale = new Vector3(tp.x * scale, tp.y * scale, tp.z * scale);
        //print(circlePlaneObject.transform.position.z);
    }
}
