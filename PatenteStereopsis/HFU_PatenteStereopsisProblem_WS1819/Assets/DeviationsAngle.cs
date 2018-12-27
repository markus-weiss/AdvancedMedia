using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviationsAngle : MonoBehaviour {

    public GameObject ObjectSpawnerONE;
    public GameObject ObjectSpawnerTWO;

    private float radius;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //radius = ObjectSpawnerONE.GetComponent<Vertices>().GetRadius();
        print(ObjectSpawnerONE.GetComponent<Vertices>().GetRadius());
        print(ObjectSpawnerTWO.GetComponent<Vertices>().GetRadius());
	}
}
