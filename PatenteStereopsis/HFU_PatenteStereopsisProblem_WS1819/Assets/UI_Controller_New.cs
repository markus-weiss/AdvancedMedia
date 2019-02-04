using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller_New : MonoBehaviour {

    //=============Nah-FernPunkt=============================
    //Nah und FernpunktRange
    public float minRange = 4;
    public float maxRange = 30;
    //FernPunktSlider
    private Slider fernPunktSlider;
    private float fernPunktSliderValue;
    private Text fernPunktUIText;
    //NahPunktSlider
    private Slider nahPunktSlider;
    private float nahPunktSliderValue;
    private Text nahPunktUIText;

    //==================DeviationAngle==========================
    //DeviationMinMax
    //public float devationMin = -2;
    public float devationMax = 2;
    //DevitionAngle
    private Slider deviationAngle;
    private float deviationAngleValue;
    private Text deviationAngleUIText;

    //==================EyeDistance==========================
    // Eye Dist minmax lässt sich nicht setzen
    //EyeDistanceRange
    public float eyeDistmin = 30;
    public float eyeDistmax = 80;
    //EyeDistance
    private Slider eyeDistance;
    private float eyeDistanceValue;
    private Text eyeDistanceUIText;


    //===============Cameras================
    private Camera VR_Camera;
    private Camera TopDownCamera;

	// Use this for initialization
	void Awake () {


        GetFernPunktSliderObjects();
        SetUIValuesObjects();
    }
	
	// Update is called once per frame
	void Update () {

        // Get Values from UI
        SetSliderValues();

        // Set Range Of Values
        SetSliderRange();

        // Set ValueTexts pf UI
        SetUIValues();

    }

    private void GetFernPunktSliderObjects()
    {
        fernPunktSlider = GameObject.Find("FernPunktSlider").GetComponentInChildren<Slider>();
        nahPunktSlider = GameObject.Find("NahPunktSlider").GetComponentInChildren<Slider>();
        eyeDistance = GameObject.Find("EyeDistance").GetComponentInChildren<Slider>();
        deviationAngle = GameObject.Find("DeviationAngleSlider").GetComponentInChildren<Slider>();

    }

    // Setz die slider values von 0 - 1 auf passende Maße
    private void SetSliderValues()
    {
        fernPunktSliderValue = fernPunktSlider.value * 30;
        nahPunktSliderValue = nahPunktSlider.value * 30;
        deviationAngleValue = deviationAngle.value * 3;
        eyeDistanceValue = eyeDistance.value * 100;
 
    }

    private void SetUIValuesObjects()
    {
        fernPunktUIText = GameObject.Find("FernPunktValue").GetComponentInChildren<Text>();
        nahPunktUIText = GameObject.Find("NahPunktValue").GetComponentInChildren<Text>();
        deviationAngleUIText = GameObject.Find("DeviationValue").GetComponentInChildren<Text>();
        eyeDistanceUIText = GameObject.Find("EyeDisValue").GetComponentInChildren<Text>();

    }

    private void SetUIValues()
    {
        fernPunktUIText.text = fernPunktSliderValue.ToString("00") + "m";
        nahPunktUIText.text = nahPunktSliderValue.ToString("00") + "m";
       
        deviationAngleUIText.text = System.Math.Round(deviationAngleValue,2).ToString("") + "'";
        eyeDistanceUIText.text = eyeDistanceValue.ToString("00") + "mm";
       

    }

    //To Call From OutSide to get UI Values
    public float FernPunktSliderValue()
    {
        return fernPunktSliderValue;

    } 

    // Nicht Implementiert 
    private void SetSliderRange()
    {
        
        // RangeFunktion FernPunkt
        if (fernPunktSliderValue < minRange)
        {
            fernPunktSliderValue = minRange;
        }
        else if (fernPunktSlider.value > maxRange)
        {
            fernPunktSliderValue = maxRange;
        }

        // RangeFunktion NahPunkt
        if (nahPunktSlider.value < minRange)
        {
            nahPunktSliderValue = minRange;
        }
        else if (nahPunktSlider.value > maxRange)
        {
            nahPunktSliderValue = maxRange;
        }


        
        // EyeDist Funktion
        if (eyeDistanceValue < eyeDistmin)
        {
            eyeDistanceValue = eyeDistmin;
        }
        else if (eyeDistanceValue > eyeDistmax)
        {
            eyeDistanceValue = eyeDistmax;
        }
        
        /*
        // DevAngle Funktion
        if (deviationAngle.value < 0.5f)
        {
            deviationAngleValue = devationMin * -1;
        }
        else if (deviationAngleValue >= 0.5f)
        {
            deviationAngleValue = devationMax * 1;
        }
        */
    }

}
