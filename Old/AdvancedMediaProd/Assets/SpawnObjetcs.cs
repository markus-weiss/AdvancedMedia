using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjetcs : MonoBehaviour {

    // Radius for first Layer Objects
    [Range(5, 10)]
    public float spawnradius_fo;

    // Radius for sceond Layer Objects
    // Have to be out of Patent Stereopsis to First Layer
    [Range(10, 30)]
    public float spawnradius_so;

    public GameObject prefab;

    public List<GameObject> firstLayerList;
    public List<GameObject> secondLayerList;



    private void Start()
    {
        LayerObjects(prefab, spawnradius_fo, firstLayerList);
        LayerObjects(prefab, spawnradius_so, secondLayerList);

    }

    private void LayerObjects(GameObject prefab ,float radius, List<GameObject> Layer)
    {
        // first ObjectLayer
        Vector3 pos = RandomCircle(transform.position, radius);
        Quaternion rot = Quaternion.FromToRotation(Vector3.forward, transform.position - pos);
        GameObject uiObj = Instantiate(prefab, pos, rot);
        uiObj.transform.SetParent(transform);
        Layer.Add(uiObj);
    }

    private void Update()
    {
        spawnradius_so = spawnradius_fo * spawnradius_fo;
        setLayerObjectPos(firstLayerList, spawnradius_fo);
        setLayerObjectPos(secondLayerList, spawnradius_so);

    }

    public void setLayerObjectPos(List<GameObject> goList, float radius)
    {
        foreach (GameObject go in goList)
        {
            go.transform.position = new Vector3(transform.position.x + radius * Mathf.Sin(90 * Mathf.Deg2Rad), transform.position.y, transform.position.z);
        }
    }

    Vector3 RandomCircle(Vector3 center, float radius)
    {
        //float ang = Random.value * 360;
        float ang = 90;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y;
        pos.z = center.z;
        return pos;
    }

}
