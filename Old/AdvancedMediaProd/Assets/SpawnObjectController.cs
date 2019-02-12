using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectController : MonoBehaviour {

    public GameObject vrCam;
    public Vector3 playerPos;

    public int countOfObjects;
    public GameObject cylinderPrefab;

    [Range(5,30)]
    public float radius;

	// Use this for initialization
	void Start () {

    }

	// Update is called once per frame
	void Update () {

        playerPos = GetPlayerPos(vrCam);
        //Debug.Log(playerPos.x + " : " + playerPos.y + " : " + playerPos.z);
        if (Input.GetKeyUp(KeyCode.A)){
            SpawnObjects();
            refreshObjectPos();
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            Vector3 pos = RandomCircle(playerPos, 20);
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, playerPos - pos);
            GameObject uiObj = Instantiate(cylinderPrefab, pos, rot);
            uiObj.transform.SetParent(vrCam.transform);
        }

        foreach (Transform child in vrCam.transform)
        {
            refreshObjectPos();
        }
    }

    public void refreshObjectPos()
    {
        foreach (Transform child in vrCam.transform)
        {
            setPos(child);
        }
    }

    public void setPos(Transform child)
    {
        child.transform.position = RandomCircle(playerPos, radius);
    }

    Vector3 RandomCircle(Vector3 center, float radius)
    {
        //float ang = Random.value * 360;
        float ang = 90;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        //pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.y = center.y;
        pos.z = center.z;
        return pos;
    }

    public void SpawnObjects()
    {
        Vector3 center = playerPos;
        for (int i = 0; i < countOfObjects; i++)
        {
            Vector3 pos = RandomCircle(center, radius);
            Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);
            GameObject uiObj = Instantiate(cylinderPrefab, pos, rot);
            uiObj.transform.SetParent(vrCam.transform);

        }
    }

    public Vector3 GetPlayerPos(GameObject VRCam)
    {
        return VRCam.gameObject.transform.position;
    }
}
