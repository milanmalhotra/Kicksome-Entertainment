using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TradingSystem : MonoBehaviour
{
    public void OnClickSubmit()
    {
        //print("Delivering " + GetActiveListing.listingCost + " to " + GetActiveListing.listingGamerTag);
        print("Going to do a deal with drug runner");
        Cursor.lockState = CursorLockMode.Locked;
        PlayerMovement.playerHasInput = true;
        GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
        StartCoroutine(MoveDrugsSystem.GiveMuleCollider());
    }
}
