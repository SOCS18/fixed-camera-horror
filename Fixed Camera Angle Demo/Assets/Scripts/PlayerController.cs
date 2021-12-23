using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float rotationSpeed = 45f;
    [SerializeField] private Camera mainCam;
    private int numCamLocations;
    public GameObject camParent;
    public Transform[] camLocations;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCam = Camera.main;
        camParent = GameObject.FindGameObjectWithTag("CameraLocations");
        numCamLocations = camParent.transform.childCount;
        camLocations = new Transform[numCamLocations];
        for (int i = 0; i < numCamLocations; i++)
        {
            Debug.Log(i);
            camLocations[i] = camParent.transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float playerMovement = Input.GetAxis("Vertical");
        float playerRotation = Input.GetAxis("Horizontal");

        transform.Translate(0, 0, playerSpeed * playerMovement * Time.deltaTime);
        transform.Rotate(0, playerRotation * rotationSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cam1Collider")
        {
            Debug.Log("Turn on cam 1");
        }
        if (other.gameObject.name == "Cam2Collider")
        {
            Debug.Log("Turn on cam 2");
        }
        if (other.gameObject.name == "Cam3Collider")
        {
            Debug.Log("Turn on cam 3");
        }
        if (other.gameObject.name == "Cam4Collider")
        {
            Debug.Log("Turn on cam 4");
        }
    }
}
