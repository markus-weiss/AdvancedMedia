using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NahPunktObjectSpawner : MonoBehaviour {

    public Transform objectprefab;
    private Transform inst;

    public GameObject UI_Controller;
    private float sliderValue;

    public GameObject DevAngleObj;

    private float rotateValue;

    private float nahPunktDist;

    void Start()
    {



        inst = Instantiate(objectprefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + nahPunktDist + 7.8f), Quaternion.Euler(90, 0, 0));
        inst.transform.SetParent(transform);

   }

    // Update is called once per frame
    void Update()
    {
        nahPunktDist = DevAngleObj.GetComponent<DeviationsAngle>().getNPdistancetoZero();
        //rotateValue = GetComponentInParent<Transform>().transform.eulerAngles.y;
        //sliderValue = DevAngleObj.GetComponent<DeviationsAngle>().getNPdistancetoZero();

        inst.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + nahPunktDist);
        print(nahPunktDist);
        //inst.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + sliderValue);
        //inst.transform.eulerAngles = new Vector3(0, rotateValue,0);
        //transform.eulerAngles = new Vector3(0, rotateValue,0);

        //inst.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + sliderValue);
        //inst.RotateAround(transform.parent.position, Vector3.up, rotateValue);


    }
}
