using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionCheck : MonoBehaviour
{
    public GameObject player;
    public static bool isPlayerBehind;
    

    void Start()
    {
        
    }

    public void VaultPositionCheck()
    {
        Vector3 relativePoint = transform.InverseTransformPoint(player.transform.position);
        if (relativePoint.z < 0.0)
        {
            isPlayerBehind = true;
        }
        else if (relativePoint.z > 0.0)
        {
            isPlayerBehind = false;
        }
        
    }
}
