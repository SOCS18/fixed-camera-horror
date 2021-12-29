using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float rotationSpeed = 60f;
    [SerializeField] private Camera mainCam;
    [SerializeField] private Animator anim;
    [SerializeField] private bool isWalking;
    [SerializeField] private bool isTurning;
    private int numCamLocations;
    public GameObject camParent;
    public Transform[] camLocations;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!anim)
            anim = GetComponent<Animator>();

        isWalking = false;
        isTurning = false;

        rb = GetComponent<Rigidbody>();

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
        float playerMovement = Input.GetAxis("Vertical");
        float playerRotation = Input.GetAxis("Horizontal");

        transform.Translate(0, 0, playerSpeed * (playerMovement / 4f) * Time.deltaTime);
        transform.Rotate(0, playerRotation * rotationSpeed * Time.deltaTime, 0);

        if (playerMovement != 0)
            isWalking = true;
        else
            isWalking = false;

        if (isWalking == false)
            anim.SetBool("isWalking", false);

        if (isWalking == true)
        {
            anim.SetBool("isWalking", true);
            anim.SetFloat("walkSpeed", Input.GetAxis("Vertical") / 4f);
        }

        if (playerRotation != 0)
            isTurning = true;
        else
            isTurning = false;

        if (isTurning == false)
            anim.SetBool("isTurning", false);

        if (isTurning == true)
        {
            anim.SetBool("isTurning", true);
            anim.SetFloat("turnSpeed", Input.GetAxis("Horizontal"));
        }

        if (isTurning == true && isWalking == true)
            anim.SetFloat("turnSpeed", 0);
    }

    private void OnTriggerEnter(Collider other)
    {
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
