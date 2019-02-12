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
    private Vector3[] vertices;
    Vector3[] verticesOrigin;
    List<Vector3> VertexList;

    public GameObject lookAtTarget;
    public GameObject prefab;
    GameObject inst;

    Vector3 radiusToZero;

    //Linrenderer Colors for Children
    public Color c1 = new Color(1, 1, 1, 0);
    public Color c2 = new Color(1, 1, 1, 0.3f);

    void Start()
    {
        VertexList = new List<Vector3>();
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;

        foreach (Vector3 vertex in vertices)
        {
            VertexList.Add(vertex);
        }
        VertexList = VertexList.Distinct().ToList();

        foreach (Vector3 vertex in VertexList)
        {
            inst = Instantiate(prefab, vertex, Quaternion.identity);
            inst.transform.SetParent(transform);
            inst.transform.LookAt(transform);
            inst.transform.Rotate(Vector3.right, 90);
        }
    }

    void Update()
    {
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
            child.position = new Vector3(VertexList[i].x * radius, VertexList[i].y * radius, VertexList[i].z * radius);

            i++;
        }
        i = 0;

    }

    //Is the fastest way to get it!
    public float GetRadius()
    {
        return VertexList[0].y * radius;
    }
}
