using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class UI_ControllerScript : MonoBehaviour {

    //public GameObject uIDevAngleValue;
    public Slider uIDevAngleSlider;

    //public GameObject uIFernpunktValue;
    [Range(4,29)]
    public Slider uIFernpunktSlider;

    public Text uiDeviationText;
    [Range(-2,2)]
    public Slider uiDeviationAngleSlider;
    private float devSliderValue;

    public Camera topDownCamera;
    public Camera fristPersonCamera;

    public GameObject ScreenFirstPerson;
    public GameObject ScreenTopDown;

    public Toggle deviationKegelToggle;
    public Toggle vRKegelToggle;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public float getDevSliderValue()
    {
        return uiDeviationAngleSlider.value;
    }

    public float getUIDevAngleSlider()
    {
        return uIDevAngleSlider.value;
    }
    public float getUIFernpunktSlider()
    {
        return uIFernpunktSlider.value;
    }
    public bool GetdeviationKegelToggle()
    {
        return deviationKegelToggle.isOn;
    }
    public bool GetVRKegelToggle()
    {
        return vRKegelToggle.isOn;
    }

    public void setDeviationSliderText()
    {

       // uiDeviationText.text = devSliderValue.ToString("00") + "m";

    }
}
