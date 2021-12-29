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
    [SerializeField] private bool isPaused;
    [SerializeField] private GameObject gameController;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private CameraController cameraController;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!anim)
            anim = GetComponent<Animator>();

        isWalking = false;
        isTurning = false;

        rb = GetComponent<Rigidbody>();

        cameraController = gameController.GetComponent<CameraController>();
        inventoryPanel = GameObject.Find("Inventory");

        isPaused = false;
        inventoryPanel.SetActive(false);
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

        if (Input.GetKeyDown(KeyCode.E))
        {
            isPaused = !isPaused;
            PauseResumeGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        cameraController.ChangeCamPosition(other);
    }

    void PauseResumeGame()
    {
        if (isPaused)
        {
            Time.timeScale = 0f;
            inventoryPanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            inventoryPanel.SetActive(false);
        }
    }
}
