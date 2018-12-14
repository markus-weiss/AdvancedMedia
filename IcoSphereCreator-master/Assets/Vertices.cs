using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertices : MonoBehaviour {

    [Range(1,30)]
    public float radius;

    Mesh mesh;
    Vector3[] vertices;
    Vector3[] verticesOrigin;


    public GameObject prefab;
    GameObject inst;

    Vector3 radiusToZero;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        verticesOrigin = mesh.vertices;

        foreach(Vector3 vertex in vertices)
        {
            inst =  Instantiate(prefab, vertex, Quaternion.identity);
            inst.transform.SetParent(transform);
            //Layer.Add(inst);
            float dist = Vector3.Distance(inst.transform.position, transform.position);
            //print("Distance to other: " + dist);
        }
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            radius--;
            setRadius();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            radius++;
            setRadius();
        }
        print(radius);
        setRadius();
    }

    void setRadius()
    {
        //radius = Random.Range(2, 5);
        var i = 0;
        foreach (Transform child in transform)
        {
            child.position = new Vector3(verticesOrigin[i].x * radius, verticesOrigin[i].y * radius, verticesOrigin[i].z * radius);
            child.transform.LookAt(transform);
            i++;
        }
        i = 0;
    }


}
