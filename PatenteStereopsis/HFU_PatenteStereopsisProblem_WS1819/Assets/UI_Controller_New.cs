using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller_New : MonoBehaviour {


    //====================CamScreenToggles=================================
    private GameObject OnOffVrCam;
    private GameObject OnOff3rdCam;
    private Toggle vr;
    private Toggle rd;
    private GameObject vrCamUITexture;
    private GameObject rdCamUITexture;



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
        rdCamUITexture = GameObject.Find("TopDownCamera");

        // Get Objects
        OnOffVrCam = GameObject.Find("VR-Toggle");
        OnOff3rdCam = GameObject.Find("3rd-PersonToggle");

        // Set Slider
        fernPunktSlider = GameObject.Find("FernPunktSlider").GetComponentInChildren<Slider>();
        nahPunktSlider = GameObject.Find("NahPunktSlider").GetComponentInChildren<Slider>();
        ObjectSlider = GameObject.Find("ObjektScale").GetComponentInChildren<Slider>();
        eyeDistanceSlider = GameObject.Find("EyeDistance").GetComponentInChildren<Slider>();       
        deviationAngleSlider = GameObject.Find("DeviationAngleSlider").GetComponentInChildren<Slider>();

        // Set Text Objects
        fernPunktUIText = GameObject.Find("FernPunktValue").GetComponentInChildren<Text>();
        nahPunktUIText = GameObject.Find("NahPunktValue").GetComponentInChildren<Text>();
        ObjectScaleText = GameObject.Find("ObjectScaleValue").GetComponentInChildren<Text>();
        eyeDistanceUIText = GameObject.Find("EyeDisValue").GetComponentInChildren<Text>();
        deviationAngleUIText = GameObject.Find("DeviationValue").GetComponentInChildren<Text>();

        //SliderColorObjects
        sliderBackground = GameObject.Find("Dev_Background");
        sliderFill = GameObject.Find("Dev_Fill");


        eyeDistanceSlider.value = 65;

        SetCameraToggleEvent();
    }



    // Update is called once per frame
    void Update () {


        ControllNahPunktWithFernPunkt();

        fernPunktUIText.text = fernPunktSlider.value.ToString("00") + "m";
        nahPunktUIText.text = nahPunktSlider.value.ToString("00") + "m";
        ObjectScaleText.text =  System.Math.Round(ObjectSlider.value,2).ToString("");
        eyeDistanceUIText.text = System.Math.Round(eyeDistanceSlider.value).ToString("") + "mm";

        deviationAngleUIText.text = System.Math.Round((deviationAngle * 1000 * -1),2).ToString("00") + "'";
        deviationAngleSlider.value = (deviationAngle * 1000 *-1);

        SetDevSliderColor();
        calculationDevAngle();
    }

    private void calculationDevAngle()
    {
        float gamma = Mathf.Atan((eyeDistanceSlider.value * 0.001f / 2) / fernPunktSlider.value);
        float alpha = Mathf.Atan((eyeDistanceSlider.value * 0.001f / 2) / nahPunktSlider.value);
        float beta = gamma - alpha;
        deviationAngle = beta * 2;

        print(deviationAngle);
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


    void SetCameraToggleEvent()
    {
        // Get Toggles from Objects
        vr = OnOffVrCam.GetComponent<Toggle>();
        rd = OnOff3rdCam.GetComponent<Toggle>();

        vr.onValueChanged.AddListener(delegate {ToggleValueChanged(vr);});
        rd.onValueChanged.AddListener(delegate {ToggleValueChanged(rd);});

    }

    void ToggleValueChanged(Toggle change)
    {

        vrCamUITexture.SetActive(vr.isOn);
        rdCamUITexture.SetActive(rd.isOn);
        //print(vr.isOn + ":" + rd.isOn);
    }


}
