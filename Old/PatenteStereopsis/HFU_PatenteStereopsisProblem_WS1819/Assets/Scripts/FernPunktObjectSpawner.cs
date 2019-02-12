using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FernPunktObjectSpawner : MonoBehaviour {

    public Transform objectprefab;
    private Transform inst;

    public GameObject UI_Controller;
    private float sliderValue;

    private float rotateValue;

    void Start()
    {
        inst = Instantiate(objectprefab, new Vector3(transform.position.x, transform.position.y, transform.position.z + sliderValue + 7.8f), Quaternion.Euler(90,0,0));
        inst.transform.SetParent(transform);


    }

    // Update is called once per frame
    void Update () {
        
        rotateValue = GetComponentInParent<Transform>().transform.eulerAngles.y;
        sliderValue = UI_Controller.GetComponent<UI_ControllerScript>().getUIFernpunktSlider() * 30;

        //inst.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + sliderValue);
        //inst.transform.eulerAngles = new Vector3(0, rotateValue,0);
        //transform.eulerAngles = new Vector3(0, rotateValue,0);

        //inst.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + sliderValue);
        //inst.RotateAround(transform.parent.position, Vector3.up, rotateValue);
        

    }
}
