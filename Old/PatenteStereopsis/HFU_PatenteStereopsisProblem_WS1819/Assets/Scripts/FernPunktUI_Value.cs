using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class FernPunktUI_Value : MonoBehaviour {

    public GameObject UI_Controller;

    public Text text;
    private float sliderValue;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        sliderValue = UI_Controller.GetComponent<UI_ControllerScript>().getUIFernpunktSlider() * 30;
        //text = transform.GetComponent<Text>();
        text.text = sliderValue.ToString("00") + "m";
        //text.text = "a";
    }
}
