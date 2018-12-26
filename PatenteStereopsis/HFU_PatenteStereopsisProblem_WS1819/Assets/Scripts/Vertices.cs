using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vertices : MonoBehaviour {

    [Range(0.01f,30)]
    public float radius;

    //Unfinish
    [Range(1, 8)]
    public float scale;
    

    Mesh mesh;
    public Vector3[] vertices;
    Vector3[] verticesOrigin;

    public GameObject lookAtTarget;
    public GameObject prefab;
    GameObject inst;

    Vector3 radiusToZero;

    //Linrenderer Colors for Children
    public Color c1 = new Color(1, 1, 1, 0);
    public Color c2 = new Color(1, 1, 1, 0.3f);

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
        //print(radius);
        setRadius();
        setScale();

    }

    void setScale()
    {
        foreach (Transform child in transform)
        {
            child.localScale = new Vector3(scale, 0.001f, scale);
            //child.localScale = new Vector3(radius * multiplicator,  0.001f, radius * multiplicator);
        }
    }

    void setRadius()
    {
        //radius = Random.Range(2, 5);
        var i = 0;
        foreach (Transform child in transform)
        {
            // set all spawned childs in distance to 0 0 0 with radius
            // have to set to Player
            child.position = new Vector3(verticesOrigin[i].x * radius, verticesOrigin[i].y * radius, verticesOrigin[i].z * radius);
            
            // Look at Target
            child.transform.LookAt(lookAtTarget.transform);
            
            // To look at target in y - direction
            //Unfinsih
            child.transform.Rotate(Vector3.right, 90);

            i++;
        }
        i = 0;

    }
}
