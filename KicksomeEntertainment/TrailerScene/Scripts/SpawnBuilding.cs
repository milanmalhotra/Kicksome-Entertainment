using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBuilding : MonoBehaviour
{
    public Animator anim;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }

        if(gameObject.transform.position.y <= 1)
        {
            anim.SetTrigger("trigger");
        }
    }
}
