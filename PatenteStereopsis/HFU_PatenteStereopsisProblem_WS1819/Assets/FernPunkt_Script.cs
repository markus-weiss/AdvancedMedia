using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FernPunkt_Script : MonoBehaviour {

    public GameObject UI_Controller;


    private float fernPunktValue;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        fernPunktValue  = UI_Controller.GetComponent<UI_ControllerScript>().getUIFernpunktSlider() * 30;
        //print(fernPunktValue);
        SetScale();
    }

    public void SetScale()
    {
        transform.localScale = new Vector3(fernPunktValue / 60, fernPunktValue / 60, fernPunktValue / 60);
    }
}
