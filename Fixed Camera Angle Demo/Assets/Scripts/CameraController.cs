using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera mainCam;
    public GameObject camParent;
    public Transform[] camLocations;
    private int numCamLocations;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;
        camParent = GameObject.FindGameObjectWithTag("CameraLocations");
        numCamLocations = camParent.transform.childCount;
        camLocations = new Transform[numCamLocations];

        for (int i = 0; i < numCamLocations; i++)
            camLocations[i] = camParent.transform.GetChild(i);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCamPosition(Collider other)
    {
        Debug.Log("Called Function");
        if (other.gameObject.name == "Cam1Collider")
        {
            mainCam.transform.position = camLocations[0].position;
            mainCam.transform.rotation = camLocations[0].rotation;
        }
        if (other.gameObject.name == "Cam2Collider")
        {
            mainCam.transform.position = camLocations[1].position;
            mainCam.transform.rotation = camLocations[1].rotation;
        }
        if (other.gameObject.name == "Cam3Collider")
        {
            mainCam.transform.position = camLocations[2].position;
            mainCam.transform.rotation = camLocations[2].rotation;
        }
        if (other.gameObject.name == "Cam4Collider")
        {
            mainCam.transform.position = camLocations[3].position;
            mainCam.transform.rotation = camLocations[3].rotation;
        }
    }
}
