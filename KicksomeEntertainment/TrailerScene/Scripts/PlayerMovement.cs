using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class PlayerMovement : MonoBehaviour
{
    #region DefineVariables
    //Character Movement
    [Header("Character Movement")]
    public CharacterController controller;
    public Camera mainCam;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float gravity = -15f;
    public float groundDistance = 0.4f;
    public float jumpHeight = 1f;
    public static bool isGrounded;
    public static bool isSprinting;
    public static bool isCrouching = false;
    public static bool playerHasInput;
    public float normalSpeed = 2f;
    Vector3 velocity;
    float sprintSpeed = 6f;
    float crouchSpeed = 1f;
    float playerHeight = 2f;
    float previousY = 0;
    float raycastRange = 3f;
    float x;
    float z;
    int layer8n10 = 1 << 8 | 1 << 10;

    //Sitting
    [Header("Sitting")]
    public Animation sitAnimation;
    public GameObject sitPopup;
    public GameObject standPopup;
    public static bool isSitting;
    
    //RayCast
    Ray ray;
    RaycastHit hit;
    
    #endregion

    void Start()
    {
        layer8n10 = ~layer8n10;
        playerHasInput = true;

    }
    // Update is called once per frame
    void Update()
    {
        Movement();

        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
 
        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, raycastRange, layer8n10))
        {
            
            string objectTag = hit.transform.tag;

            switch (objectTag)
            {
               
                case "Chair":
                    //sitPopup.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        playerHasInput = false;
                        
                        GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
                        sitAnimation.Play("chairSit");
                        isSitting = true;
                    }
                    break;
            
                default:
                    break;
            }

        }
       
        if (isSitting)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isSitting = false;
                sitAnimation.Play("chairStand");
                playerHasInput = true;
            }
        }
    }


    public void TakePlayerControlAway()
    {
        playerHasInput = false;
        GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
    }
    void Movement()
    {
        //creates invisible sphere around groundCheck and if it collides with ground sets true, else false
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (playerHasInput)
        {
            //sets movement inputs
            x = Input.GetAxis("Horizontal");
            z = Input.GetAxis("Vertical");

            //allows player to move based on local view not global 
            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * normalSpeed * Time.deltaTime);
        }

        //Crouch();
        Jump();
        Sprint();
    }

    void Crouch()
    {
        previousY = controller.transform.position.y - controller.height / 2 - controller.skinWidth;
        if (Input.GetButtonDown("Crouch"))
        {

            if (!isCrouching)
            {
                isSprinting = false;
                isCrouching = true;
                playerHeight = 1.5f;
                normalSpeed = crouchSpeed;
            }
            else
            {
                isCrouching = false;
                playerHeight = 2f;
                normalSpeed = 2f;
            }
        }
        if (!isSitting)
        {
            controller.height = Mathf.Lerp(controller.height, playerHeight, 5f * Time.deltaTime);
            mainCam.transform.position = Vector3.Lerp(mainCam.transform.position,
                new Vector3(mainCam.transform.position.x,
                controller.transform.position.y + playerHeight - 0.1f,
                mainCam.transform.position.z), 5f * Time.deltaTime);
            controller.transform.position = Vector3.Lerp(controller.transform.position,
                new Vector3(controller.transform.position.x,
                previousY + playerHeight / 2 + controller.skinWidth,
                controller.transform.position.z), 5f * Time.deltaTime);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //keeps player on the ground
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void Sprint()
    {
        if (z > 0 && Input.GetButton("Sprint"))
        {
            normalSpeed = sprintSpeed;
            isSprinting = true;

            if (isCrouching)
            {
                isCrouching = false;
                playerHeight = 2f;
            }
            
        }
        if (Input.GetButtonUp("Sprint"))
        {
            normalSpeed = 2f;
            isSprinting = false;
        }

    }

}

