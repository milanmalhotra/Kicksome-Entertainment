using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity;
    float scopedSensitivity = 20f;

    public Transform playerBody;

    float xRotation = 0f;
    float yRotation = 0f;
 
    // Start is called before the first frame update
    void Start()
    {
        //removes cursor from view
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

       
        //set the mouse x&y movement
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
         

        //decrease xRotation based on mouseY
        xRotation -= mouseY;
            
        if (PlayerMovement.isSitting)
        {
            yRotation += mouseX;
            //restricts the player from turning their head too far up/down
            xRotation = Mathf.Clamp(xRotation, -35, 35);
            yRotation = Mathf.Clamp(yRotation, -90, 90);
               
        }
        else
        {
            yRotation = 0f;
            xRotation = Mathf.Clamp(xRotation, -60f, 60f);
        }

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

        if(!PlayerMovement.isSitting)
            //move player left/right when mouse is going across x axis
            playerBody.Rotate(Vector3.up * mouseX);

       
        
    }
}
