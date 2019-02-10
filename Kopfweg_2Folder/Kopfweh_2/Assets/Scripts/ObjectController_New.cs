﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController_New : MonoBehaviour {

    private GameObject UI_Controller;

    // Nah und FernPunkt
    // TopDownCircle
    //[Range(2, 30)]
    public float fernObjektScale;
    private GameObject fernObjektCircle;

    //[Range(2, 30)]
    public float nahObjektScale;
    private GameObject nahObjektCircle;


    //[Range(0.1f,1)]
    public float circleObjektScaleFaktorNah = 2f;
    private GameObject circlePlaneNahPunktObjekt;

    //public float circleObjektScaleFaktorFern = 2f;
    private GameObject circlePlaneFernPunktObjekt;

    private GameObject sphere;

    //CirclePlanObjects
    private GameObject circlePlaneParent;
    private GameObject playerVRCamera;


    //EyeCones
    private GameObject eyeConeParent;
    [Range(0.050f,0.07f)]
    public float eyedistance;
    private GameObject leftEyeParent;
    private GameObject rightEyeParent;




    private void Awake()
    {

        //GetUIKontroller
        UI_Controller = GameObject.Find("UI_Controller");

        //Setze EyeCone
        eyeConeParent = GameObject.Find("EyeConeParent");
        leftEyeParent = GameObject.Find("LeftEyeParent");
        rightEyeParent = GameObject.Find("RightEyeParent");

        //Setze Nah und FernObjekt
        circlePlaneNahPunktObjekt = GameObject.Find("CirclePlaneNahObjekt");
        circlePlaneFernPunktObjekt = GameObject.Find("CirclePlaneFernObjekt");


        sphere = GameObject.Find("30mSphere");

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
        eyedistance = 0.065f;

        fernObjektScale = 2;
        nahObjektScale = 2;

        circleObjektScaleFaktorNah = 0.5f;
        //circleObjektScaleFaktorFern = 0.5f;

    }


    // Update is called once per frame
    void Update () {

        eyedistance = UI_Controller.GetComponent<UI_Controller_New>().eyeDistanceSlider.value * 0.001f;
        //print( UI_Controller.GetComponent<UI_Controller_New>().eyeDistanceSlider.value * 0.001f);
        fernObjektScale = UI_Controller.GetComponent<UI_Controller_New>().fernPunktSlider.value;
        nahObjektScale = UI_Controller.GetComponent<UI_Controller_New>().nahPunktSlider.value;
        //print(UI_Controller.GetComponent<UI_Controller_New>().nahPunktSliderValue);
        circleObjektScaleFaktorNah = UI_Controller.GetComponent<UI_Controller_New>().ObjectSlider.value;

        //SetEyeDistance
        SetEyeDistance(eyedistance ,leftEyeParent, rightEyeParent);

        // EyeCones look at Target
        LookAtObject(leftEyeParent, circlePlaneNahPunktObjekt);
        LookAtObject(rightEyeParent, circlePlaneNahPunktObjekt);

        //SetVRCameraOrientaionToObjectParent(playerVRCamera);
        setObjectAsRotationParent(circlePlaneParent.transform, playerVRCamera.transform);
        setObjectAsPositionParent(circlePlaneParent.transform, playerVRCamera.transform);

        //Der Scale des Objekts wird über den Faktor gesetzt
        setCircleObjectScale(circlePlaneNahPunktObjekt, circleObjektScaleFaktorNah);

        //setCircleObjectScale(sphere, circleObjektScaleFaktorNah +0.1f);

        //Scale der Sphere
        SetSphereObjectScale(sphere, fernObjektScale);

        //Sorge dafür das, das nahpunktObjekt immer näher ist 
        if (nahObjektScale >= fernObjektScale)
        {
            //nahObjektScale = fernObjektScale;
            fernObjektScale = nahObjektScale;
            //nahObjektScale = nahObjektScale;
        }
        
        else if (fernObjektScale < nahObjektScale)
        {
            nahObjektScale = fernObjektScale;
        }
        
        else
        {

            //CircleScale(nahObjektCircle, nahObjektScale);

            //Die Position kann über den Scale gesetzt werden
            //setCircleObjectPositions(circlePlaneNahPunktObjekt, nahObjektScale);
        }
        CircleScale(nahObjektCircle, nahObjektScale);
        setCircleObjectPositions(circlePlaneNahPunktObjekt, nahObjektScale);

    }


    // Set die halbe augendistanze für jedes auge in plus und minus x
    public void SetEyeDistance(float eyedistance, GameObject leftEye, GameObject rightEye)
    {
        Vector3 tp = transform.position;
        Vector3 leftEyePos = leftEye.transform.localPosition;
        Vector3 rightEyePos = rightEye.transform.localPosition;

        leftEye.transform.localPosition = new Vector3(tp.x + eyedistance / 2, tp.y, tp.z);
        rightEye.transform.localPosition = new Vector3(tp.x - eyedistance / 2, tp.y, tp.z);
        //print(rightEyePos.x);
    }

    // Schaut auf LookAt Object
    public void LookAtObject(GameObject eye, GameObject target)
    {
        eye.transform.LookAt(target.transform);
    } 


    public void setObjectAsRotationParent(Transform childObject, Transform parentObject)
    {
        childObject.rotation = parentObject.rotation;
        //childObject.RotateAround(parentObject,);
        //childObject.transform.rotation = parentObject.transform.rotation;
        //childObject.LookAt(parentObject);
    }
    public void setObjectAsPositionParent(Transform childObject, Transform parentObject)
    {
        childObject.position = parentObject.position;
        //childObject.RotateAround(parentObject,);
        //childObject.transform.rotation = parentObject.transform.rotation;
        //childObject.LookAt(parentObject);
    }

    public void CircleScale(GameObject objectToScale ,float scale)
    {
        objectToScale.transform.localScale = new Vector3(scale / 60, scale / 60 , scale  / 60);
        //print(scale);
    }

    public void setCircleObjectPositions(GameObject circlePlaneObject, float position)
    {
        var tp =  transform.position;
        circlePlaneObject.transform.localPosition = new Vector3(tp.x, tp.y, tp.z + position);
        //print(circlePlaneObject.transform.position.z);
    }

    public void SetSphereObjectScale(GameObject sphere, float scale)
    {
        //var ts = sphere.transform.localScale;
        sphere.transform.localScale = new Vector3(scale*2, scale*2, scale*2);

    }


    public void setCircleObjectScale(GameObject circlePlaneObject, float scale)
    {
        float distanceFaktor = circlePlaneObject.transform.localPosition.z;
        var ts = transform.localScale;

        //circlePlaneObject.transform.localScale = new Vector3(scale / 60, scale / 60, scale / 60);
        circlePlaneObject.transform.localScale = new Vector3(ts.x * distanceFaktor * scale, ts.y* 0.001f , ts.z* distanceFaktor * scale);
        //print(circlePlaneObject.transform.position.z);
    }
}
