using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController_New : MonoBehaviour {


    // Nah und FernPunkt
    // TopDownCircle
    private GameObject fernPunktCircle;
    [Range(4,30)]
    public float fernPunktScale;

    private GameObject nahPunktCircle;
    [Range(4, 30)]
    public float NahpunktScale;


    // VR Camera CirclePlanObjects
    private GameObject circlePlaneParent;

    private GameObject circlePlaneNahPunkt;
    private GameObject circlePlaneFernPunkt;


    private void Awake()
    {
        circlePlaneParent = GameObject.Find("CircleParent");
        circlePlaneFernPunkt = GameObject.Find("CirclePlanFernPunkt");
        circlePlaneNahPunkt = GameObject.Find("CirclePlaneNahPunkt");

        fernPunktCircle = GameObject.Find("FernPunktCircle");
        nahPunktCircle = GameObject.Find("NahPunktCircle");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CircleScale(fernPunktCircle, fernPunktScale);
        CircleScale(nahPunktCircle, NahpunktScale);

	}

    public void CircleScale(GameObject objectToScale ,float scale)
    {
        objectToScale.transform.localScale = new Vector3(scale / 60, scale / 60, scale / 60);
    }

    public void setCirclePositions(string valuename)
    {

    }
}
