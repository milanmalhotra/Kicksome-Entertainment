using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SearchListingController : MonoBehaviour
{
    public GameObject yabInfo;
    public GameObject ngodInfo;
    public GameObject sdemInfo;
    GameObject yabba;
    GameObject ngod;
    GameObject sdem;
    bool isOpen = false;
    
    public void OpenListingInfo(Button button)
    {
        if (button.name == "YabbaDabbaDoo")
            yabInfo.SetActive(!isOpen);
        else if (button.name == "NGodofPainM")
            ngodInfo.SetActive(!isOpen);
        else if (button.name == "SDemonofTruthM")
            sdemInfo.SetActive(!isOpen);
        isOpen = !isOpen;
    }

    public void AcceptButton()
    {
        print("Accepted Listing");
        Cursor.lockState = CursorLockMode.Locked;
        PlayerMovement.playerHasInput = true;
        GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
        PlayerMovement.compCollider.enabled = true;
    }

    public void Exit()
    {
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
        PlayerMovement.compCollider.enabled = true;
        if (!PlayerMovement.isSitting)
            PlayerMovement.playerHasInput = true;
    }
}
