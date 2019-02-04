using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class SetDeviationAngleValue : MonoBehaviour {

    public GameObject UI_Controller;

    public Text text;
    [Range(-2,2)]
    private float sliderValue;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        sliderValue = UI_Controller.GetComponent<UI_ControllerScript>().getDevSliderValue();
        //text = transform.GetComponent<Text>();
        text = GetComponent<Text>();
        //text.text = sliderValue.ToString("") + "°";
        //text.text = "a";
    }
}
