using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsNPC : MonoBehaviour
{
    
    public float speed = 2f;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        if (NPC.isAggro)
        {
            Vector3 dir = target.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, speed * Time.deltaTime);
        }
    }
}
