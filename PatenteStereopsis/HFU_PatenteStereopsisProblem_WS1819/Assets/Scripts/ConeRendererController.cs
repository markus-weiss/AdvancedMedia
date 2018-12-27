using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConeRendererController : MonoBehaviour {

    //LineRenderer lineRenderer;
    private Transform lineTarget;

    private Transform startObject;
    public int lengthOfLineRenderer;

    //Linrenderer Colors
    Color c1;
    Color c2;

    private void Start()
    {
        c1 = GetComponentInParent<Vertices>().c1;
        c2 = GetComponentInParent<Vertices>().c2;
    }

    private void Update()
    {
        //Set Objects
        startObject = transform.parent;
        lineTarget = transform;

        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        //LineRenderer lineRenderer = new LineRenderer();

        //Set Color
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = c1;
        lineRenderer.endColor = c2;

        //Set start target
        Vector3 startPos = startObject.position;
        lineRenderer.SetPosition(0, startPos);

        //Set Target Scale and Position
        Vector3 targetPos = lineTarget.position;
        Transform targetScale = lineTarget;

        lineRenderer.SetPosition(1, targetPos);
        lineRenderer.widthMultiplier = targetScale.localScale.x;

    }

}
