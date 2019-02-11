using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller_New : MonoBehaviour {


    //====================CamScreenToggles=================================
    private GameObject OnOffVrCam;
    private GameObject OnOff3rdCam;
    private Toggle vrToggle;
    private Toggle trdToggle;
    private GameObject vrCamUITexture;
    private GameObject topDownCamera;



    //=============Nah-FernPunkt=============================
    //FernPunktSlider
    public Slider fernPunktSlider;
    private Text fernPunktUIText;
    public Slider nahPunktSlider;
    private Text nahPunktUIText;


    //==================DeviationAngle==========================
    //DevitionAngle
    private float deviationAngle;
    private Slider deviationAngleSlider;
    private Text deviationAngleUIText;

    //==================EyeDistance==========================
    // Eye Dist minmax lässt sich nicht setzen
    //EyeDistance
    public Slider eyeDistanceSlider;
    private Text eyeDistanceUIText;
    private GameObject sliderBackground;
    private GameObject sliderFill;

    //======================ObjectScale)============================
    public Slider ObjectSlider;
    private Text ObjectScaleText;

    //===============Cameras================
    private Camera VR_Camera;
    private Camera TopDownCamera;






	// Use this for initialization
	void Awake () {

        // Set Cam Objets
        vrCamUITexture = GameObject.Find("VR_Camera");
        topDownCamera = GameObject.Find("TopDownCamera_UI");



        // Get Objects
        OnOffVrCam = GameObject.Find("VR-Toggle");
        OnOff3rdCam = GameObject.Find("3rd-PersonToggle");

        // Set Slider
        fernPunktSlider = GameObject.Find("FernPunktSlider").GetComponentInChildren<Slider>();
        nahPunktSlider = GameObject.Find("NahPunktSlider").GetComponentInChildren<Slider>();
        ObjectSlider = GameObject.Find("ObjektScale").GetComponentInChildren<Slider>();
        eyeDistanceSlider = GameObject.Find("EyeDistance").GetComponentInChildren<Slider>();       
        deviationAngleSlider = GameObject.Find("DeviationAngleSlider").GetComponentInChildren<Slider>();
        eyeDistanceSlider.value = 65;
        ObjectSlider.value = 0.1f;

        // Set Text Objects
        fernPunktUIText = GameObject.Find("FernPunktValue").GetComponentInChildren<Text>();
        nahPunktUIText = GameObject.Find("NahPunktValue").GetComponentInChildren<Text>();
        ObjectScaleText = GameObject.Find("ObjectScaleValue").GetComponentInChildren<Text>();
        eyeDistanceUIText = GameObject.Find("EyeDisValue").GetComponentInChildren<Text>();
        deviationAngleUIText = GameObject.Find("DeviationValue").GetComponentInChildren<Text>();

        //SliderColorObjects
        sliderBackground = GameObject.Find("Dev_Background");
        sliderFill = GameObject.Find("Dev_Fill");


        
        // Get Toggles from Objects
        vrToggle = OnOffVrCam.GetComponent<Toggle>();
        trdToggle = OnOff3rdCam.GetComponent<Toggle>();

        vrToggle.onValueChanged.AddListener(delegate { ToggleValueChanged(vrCamUITexture,vrToggle); });
        trdToggle.onValueChanged.AddListener(delegate { ToggleValueChanged(topDownCamera,trdToggle); });

        //rdCamUITexture.SetActive(false);
    }

    void ToggleValueChanged(GameObject gameObject, Toggle change)
    {
        gameObject.SetActive(change.isOn);
    }






    // Update is called once per frame
    void Update () {

        ControllNahPunktWithFernPunkt();

        // Slider Text
        fernPunktUIText.text = System.Math.Round(fernPunktSlider.value,1).ToString() + "m";
        nahPunktUIText.text = System.Math.Round(nahPunktSlider.value,1).ToString("") + "m";
        ObjectScaleText.text =  System.Math.Round(ObjectSlider.value,2).ToString("");
        eyeDistanceUIText.text = System.Math.Round(eyeDistanceSlider.value).ToString("") + "mm";

        // Dev Angle
        deviationAngleUIText.text = System.Math.Round((deviationAngle),2).ToString("00") + "'";
        deviationAngleSlider.value = (deviationAngle);

        SetDevSliderColor();
        calculationDevAngle();
    }

    private void calculationDevAngle()
    {

        float gamma = Mathf.Atan((fernPunktSlider.value * 100.0f) / (eyeDistanceSlider.value / 20.0f));
        float alpha = Mathf.Atan((nahPunktSlider.value * 100.0f) / (eyeDistanceSlider.value / 20.0f));
        float beta = (gamma - alpha) * 180.0f / Mathf.PI;
        //print("FP: " + fernPunktSlider.value);
        //print("EYE: " + eyeDistanceSlider.value);
        deviationAngle = beta * 120;

        //print(deviationAngle);
    }

    private void ControllNahPunktWithFernPunkt()
    {
        if(fernPunktSlider.value <= nahPunktSlider.value)
        {
            nahPunktSlider.value = fernPunktSlider.value;
        }
    }

    private void SetDevSliderColor()
    {
        Color red = new Color(255, 0, 0);
        Color yellow = new Color(255, 255, 0);
        Color green = new Color(0, 255, 0);

        if (deviationAngleSlider.value < 30)
        {
            sliderBackground.GetComponentInChildren<Image>().color = green;
        }
        else if (deviationAngleSlider.value > 30 && deviationAngleSlider.value < 40)
        {
            sliderBackground.GetComponentInChildren<Image>().color = yellow;

        }
        else if (deviationAngleSlider.value > 40)
        {
            sliderBackground.GetComponentInChildren<Image>().color = red;

        }




    }



}
