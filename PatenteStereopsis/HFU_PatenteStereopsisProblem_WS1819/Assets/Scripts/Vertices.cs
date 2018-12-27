using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Vertices : MonoBehaviour {

    [Range(0.01f,1)]
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

        //print(mesh.vertexCount);
       
        List<Vector3> VertexList = new List<Vector3>();
        foreach(Vector3 vertex in vertices)
        {
            //print(vertex);
            VertexList.Add(vertex);
        }
        VertexList = VertexList.Distinct().ToList();

        //print(VertexList.Count);

        foreach (Vector3 vertex in VertexList)
        {
            //print(vertex);
            inst = Instantiate(prefab, vertex, transform.rotation);
            inst.transform.SetParent(transform);
            //Layer.Add(inst);
            //float dist = Vector3.Distance(inst.transform.position, transform.position);
            //print("Distance to other: " + dist);
            print(inst.transform.position);    
        }
        

    }



    void Update()
    {
        //setRadius();
        //setScale();

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
