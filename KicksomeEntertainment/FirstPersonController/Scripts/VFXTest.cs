using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;

public class VFXTest : MonoBehaviour
{

    public GameObject vfx;
    public float groundLevel;
    public float offset = .3f;
    public Animator animator; 

    // Update is called once per frame
    void Update()
    {
        
        if(transform.position.y <= groundLevel)
        {
            vfx.SetActive(true);
        }

        if(transform.position.y <= groundLevel + offset)
        {
            animator.SetTrigger("trigger");
        }
    }
}
