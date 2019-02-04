using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NahPunktScript : MonoBehaviour {

    public GameObject UI_Controller;
    public GameObject DeviationAngle;

    [Range(-2,2)]
    private float nahPunktValue;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        nahPunktValue = DeviationAngle.GetComponent<DeviationsAngle>().getNPdistancetoZero();
        print(nahPunktValue);
        SetScale();
    }

    public void SetScale()
    {
        transform.localScale = new Vector3(nahPunktValue / 60, nahPunktValue / 60, nahPunktValue / 60);
    }
}
