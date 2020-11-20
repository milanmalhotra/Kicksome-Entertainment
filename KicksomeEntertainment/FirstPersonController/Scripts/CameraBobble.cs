using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBobble : MonoBehaviour
{
    public Animation anim;

    private bool stepLeft;
    private bool stepRight;
    // Start is called before the first frame update
    void Start()
    {
        stepLeft = true;
        stepRight = false;
    }

    // Update is called once per frame
    void Update()
    {
        CamAnimation();
    }

    void CamAnimation()
    {
        if(PlayerMovement.isGrounded && PlayerMovement.isSprinting && !PlayerMovement.isCrouching)
        {
            if (stepLeft && !anim.isPlaying)
            {
                anim.Play("stepLeft");
                stepLeft = false;
                stepRight = true;
            }
            if(stepRight && !anim.isPlaying)
            {
                anim.Play("stepRight");
                stepLeft = true;
                stepRight = false;
            }
        }
    }
}
