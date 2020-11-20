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
/*
    //Vaulting
    [Header("Vaulting")]
    public GameObject vaultPopup;
    public GameObject camObj;
    public GameObject wall;
    public GameObject player;
    public Vector3 startPos;
    [SerializeField]
    Vector3 vaultPos = new Vector3(0.0f, 1f, 2f);
   // PositionCheck pc;
    Collider vaultableWall;
    GameObject frontVaultPos;
    GameObject behindVaultPos;
    string vaultFile;
    bool vaulting;
    
    
    //Phone
    [Header("Phone")]
    public EventSystem eventSystem;
    public GameObject homeScreenButton1;
    public GameObject backButton;
    public GameObject homeScreen;
    public GameObject phonePanel;
    public Animator phoneAnimator;
    bool isPhoneOut;
    bool isOpen = true;
*/
    //Sitting
    [Header("Sitting")]
    public Animation sitAnimation;
    public GameObject sitPopup;
    public GameObject standPopup;
    public static bool isSitting;
    /*
    //PickUp
    [Header("Pickup")]
    public GameObject pickupPopup;

    //Mule
    [Header("Mule")]
    public GameObject mulePopup;
    public GameObject muleSentencePopup;
    public GameObject muleJobsPopup;
    public static Collider muleCollider;
    
    //Computer
    [Header("Computer")]
    public GameObject interactPopup;
    public GameObject listingHomeScreen;
    public static Collider compCollider;
    Animation homeScreenAnimation;

    //Building
    [Header("Building")]
    public GameObject buildingCanvas;
    public static bool inMenu = false;
    public static Vector3 spawnPosition;
    public static GameObject saleSign;

    //Door
    [Header("Door")]
    public float timerLimit = 5f;
    bool doorOpen;
    float timer;
    Animator doorAnim;

    //Spotter
    [Header("Spotter")]
    public GameObject spotterJobsAttack;
    public GameObject spotterJobs;
    public GameObject spotterTitle;
    public static Collider spotterCollider;

    //Hitman
    [Header("Hitman")]
    public GameObject hitmanSentence;
    public GameObject hitmanJobs;
    public static Collider hitmanCollider;
    */
    //RayCast
    Ray ray;
    RaycastHit hit;
    // Interactable interactable;
    /*
    //Sniper
    [Header("Sniper")]
    public Animator sniperAnimator;
    
    public static GameObject hello;
    */
    #endregion

    void Start()
    {
        // interactable = hit.collider.GetComponent<Interactable>();
        layer8n10 = ~layer8n10;
        playerHasInput = true;
        //homeScreenAnimation = listingHomeScreen.GetComponent<Animation>();
        //doorOpen = false;
        
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
        //PullOutPhone();
        //Vault();

        //Save
       /** if (Input.GetKeyDown(KeyCode.L))
        {
            DataLoader.Instance.SaveBuildingDataToJson();
            UnityEditor.AssetDatabase.Refresh();
        }

        //MiniMap
        if (Input.GetKeyDown(KeyCode.M))
        {
            DMMap.instance.SetFullscreen(!DMMap.instance.fullscreen);
        }*/
        ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
 
        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, raycastRange, layer8n10))
        {
            /*
            if(hit.collider.gameObject.name == "ForSaleSign")
            {
                hello = hit.collider.transform.root.gameObject;
                if (!inMenu)
                    interactPopup.SetActive(true);
                saleSign = hit.collider.gameObject;
                spawnPosition = saleSign.GetComponent<GetPositionToSpawnBuilding>().GetPosition();
                if (Input.GetKeyDown(KeyCode.F))
                {
                    inMenu = true;
                    TakePlayerControlAway();
                    buildingCanvas.SetActive(true);
                    if (inMenu)
                    {
                        interactPopup.SetActive(false);
                    }
                }
            }
            */
            string objectTag = hit.transform.tag;

            switch (objectTag)
            {
                /*
                case "Vaultable":
                    vaultFile = hit.collider.gameObject.name;
                    pc = hit.collider.gameObject.GetComponent<PositionCheck>();
                    pc.VaultPositionCheck();
                    behindVaultPos = GameObject.Find(vaultFile + "/BehindVaultPoint");
                    frontVaultPos = GameObject.Find(vaultFile + "/FrontVaultPoint");

                    vaultPopup.SetActive(true);
                    if (PositionCheck.isPlayerBehind)
                    {
                        startPos = behindVaultPos.transform.position;
                    }
                    else
                    {
                        startPos = frontVaultPos.transform.position;
                    }

                    if (Input.GetKey(KeyCode.Space))
                    {
                        transform.position = startPos;
                        vaultableWall = hit.collider;
                        vaulting = true;
                        GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
                        Vector3 lookPos = new Vector3(vaultableWall.transform.position.x, transform.position.y, vaultableWall.transform.position.z);
                        player.transform.LookAt(lookPos);
                        playerHasInput = false;
                    }
                    break;
            */
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
            /*
                case "Mule":
                    mulePopup.SetActive(true);
                    muleCollider = hit.collider;
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        muleCollider.enabled = false;
                        TakePlayerControlAway();
                        StartCoroutine(MuleDialog());
                    }
                    break;

                case "Spotter":
                    interactPopup.SetActive(true);
                    spotterCollider = hit.collider;
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        spotterCollider.enabled = false;
                        TakePlayerControlAway();
                        spotterTitle.SetActive(true);
                        if (AttackController.selectedDistrict)
                            spotterJobsAttack.SetActive(true);
                        else
                            spotterJobs.SetActive(true);

                    }
                    break;

                case "Hitman":
                    interactPopup.SetActive(true);
                    hitmanCollider = hit.collider;
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        hitmanCollider.enabled = false;
                        TakePlayerControlAway();
                        hitmanSentence.SetActive(true);
                        hitmanJobs.SetActive(true);
                    }

                    break;
                case "Computer":
                    if (isSitting)
                    {
                        interactPopup.SetActive(true);
                        compCollider = hit.collider;
                        if (Input.GetKeyDown(KeyCode.F))
                        {
                            compCollider.enabled = false;
                            TakePlayerControlAway();
                            OpenListing();
                        }
                    }
                    break;

                case "Door":
                    interactPopup.SetActive(true);
                    
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        doorAnim = hit.collider.GetComponent<Animator>();
                        doorOpen = !doorOpen;
                        doorAnim.SetBool("isOpen", doorOpen);
                        if (doorOpen)
                            timer += Time.deltaTime;
                        else
                            timer = 0f;
                    }
                    break;
            */
                default:
                    break;
            }

        }
       /* else if (vaultPopup.activeInHierarchy)
        {
            vaultPopup.SetActive(false);
        }
        else if (sitPopup.activeInHierarchy)
        {
            sitPopup.SetActive(false);
        }
        else if (pickupPopup.activeInHierarchy)
        {
            pickupPopup.SetActive(false);
        }
        else if (mulePopup.activeInHierarchy)
        {
            mulePopup.SetActive(false);
        }
        else if (interactPopup.activeInHierarchy)
        {
            interactPopup.SetActive(false);
        }*/
        if (isSitting)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isSitting = false;
                sitAnimation.Play("chairStand");
                playerHasInput = true;
            }
        }/*
        if (doorOpen)
        {
            timer += Time.deltaTime;
        }
        if(timer >= timerLimit)
        {
            doorOpen = false;
            doorAnim.SetBool("isOpen", doorOpen);
            timer = 0f;
        }*/
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
        if (z > 0 && Input.GetButton("Sprint") /**&& !Gun.isScoped**/)
        {
            normalSpeed = sprintSpeed;
            isSprinting = true;

            if (isCrouching)
            {
                isCrouching = false;
                playerHeight = 2f;
            }
            //sniperAnimator.SetBool("isSprinting", isSprinting);
        }
        if (Input.GetButtonUp("Sprint"))
        {
            normalSpeed = 2f;
            isSprinting = false;

            //sniperAnimator.SetBool("isSprinting", isSprinting);
        }

    }


  /**  void PullOutPhone()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPhoneOut)
            {
                StartCoroutine(DisablePhone());
            }
            else
            {
                phonePanel.SetActive(!isPhoneOut);
                phoneAnimator.SetBool("open", isOpen);
                eventSystem.SetSelectedGameObject(homeScreenButton1);
            }
            isPhoneOut = !isPhoneOut;
            isOpen = !isOpen;
        }
    }

    void Vault()
    {
        if (vaulting)
        {
            normalSpeed = 2f;
            Vector3 localPos = vaultableWall.transform.InverseTransformPoint(transform.position);
            Vector3 offsetPos = vaultableWall.transform.position + vaultableWall.transform.TransformDirection(vaultPos);
            Vector3 localOffsetPos = vaultableWall.transform.InverseTransformPoint(offsetPos);
            localOffsetPos.x = localPos.x;
            offsetPos = player.transform.TransformPoint(localOffsetPos);

            transform.position = Vector3.Slerp(transform.position, offsetPos, 0.1f);
            transform.rotation = Quaternion.Slerp(transform.rotation, transform.rotation, 0.1f);

            camObj.GetComponent<Animation>().Play("camVault");
            StartCoroutine(VaultTime());
        }
    }
    public void CancelButton()
    {
        GivePlayerControl();
        muleCollider.enabled = true;
        muleSentencePopup.SetActive(false);
        muleJobsPopup.SetActive(false);
    }

    void OpenListing()
    {
        interactPopup.SetActive(false);
        listingHomeScreen.SetActive(true);
        homeScreenAnimation.Play();
    }

    public void GivePlayerControl()
    {
        GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        playerHasInput = true;
    }
  */
    
        /*
    IEnumerator VaultTime()
    {
        yield return new WaitForSeconds(0.3f);
        vaulting = false;
        vaultableWall = null;
        yield return new WaitForSeconds(0.7f);
        playerHasInput = true;
        GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
    }

    IEnumerator DisablePhone()
    {
        phoneAnimator.SetBool("open", isOpen);
        yield return new WaitForSeconds(.4f);
        foreach (Transform child in phonePanel.transform)
        {
            if (child.name == "HomeScreen")
            {
                child.gameObject.SetActive(true);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
        phonePanel.SetActive(isPhoneOut);
    }
        
    IEnumerator StandUp()
    {
        yield return new WaitForSeconds(1f);
        standPopup.SetActive(true);
        if (!isSitting) {
            standPopup.SetActive(false);
        }
    }
    
    IEnumerator MuleDialog()
    {
        mulePopup.SetActive(false);
        muleSentencePopup.SetActive(true);
        yield return new WaitForSeconds(1f);
        muleJobsPopup.SetActive(true);**/
    }

