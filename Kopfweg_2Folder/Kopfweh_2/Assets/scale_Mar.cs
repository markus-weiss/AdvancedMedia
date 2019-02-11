using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scale_Mar : MonoBehaviour
{
    GameObject objectController;
    float scaleFern;
    float scaleNah;
    public float factor = 5;


    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        objectController = GameObject.Find("ObjectController");


    }

    // Update is called once per frame
    void Update()
    {
        /*
        scaleFern = objectController.GetComponent<ObjectController_New>().fernObjektScale;
        scaleNah = objectController.GetComponent<ObjectController_New>().nahObjektScale;
        print(scaleFern - scaleNah);

        GetComponent<MeshRenderer>().material.SetVector("_v1", new Vector3(scaleFern * factor, scaleFern * factor, scaleFern  * factor));
        GetComponent<MeshRenderer>().material.SetVector("_v1", new Vector3((scaleFern - scaleNah) * factor - scaleFern, (scaleFern - scaleNah) * factor - scaleFern, (scaleFern - scaleNah) * factor - scaleFern));
        */

/*
        if (scaleNah <= 2f)
        {
            GetComponent<MeshRenderer>().material.SetVector("_v1", new Vector3(scaleFern * factor, scaleFern * factor, scaleFern * factor));

        }
        else if(scaleNah >2)
        {
       }
  */     

    }


}
