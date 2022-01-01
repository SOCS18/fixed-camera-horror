using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float rotationSpeed = 60f;
    [SerializeField] private Animator anim;
    [SerializeField] private bool isWalking;
    [SerializeField] private bool isTurning;
    [SerializeField] private bool isAiming;
    [SerializeField] private bool isShooting;
    [SerializeField] private GameObject gameController;
    [SerializeField] private CameraController cameraController;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!anim)
            anim = GetComponent<Animator>();

        isWalking = false;
        isTurning = false;
        isAiming = false;
        isShooting = false;

        rb = GetComponent<Rigidbody>();

        cameraController = gameController.GetComponent<CameraController>();
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
        else
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
        else
        {
            anim.SetBool("isTurning", true);
            anim.SetFloat("turnSpeed", Input.GetAxis("Horizontal"));
        }

        if (isTurning == true && isWalking == true)
            anim.SetFloat("turnSpeed", 0);

        if (Input.GetKeyDown(KeyCode.J))
        {
            isAiming = true;
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            isAiming = false;
        }

        if (isAiming == false)
            anim.SetBool("isAiming", false);
        else
            anim.SetBool("isAiming", true);

        if (Input.GetKeyDown(KeyCode.K) && isAiming)
        {
            Debug.Log("Bang");
            isShooting = true;
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            isShooting = false;
        }

        if (isShooting == false)
            anim.SetBool("isShooting", false);
        else
            anim.SetBool("isShooting", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        cameraController.ChangeCamPosition(other);
    }
}
