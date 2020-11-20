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
  //  string fileLocation = "/ListingCanvas/SearchListingPage/ScrollList/ListViewport/ListContent/";
    
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
        /**  yabba = GameObject.Find(fileLocation + "YabInfo");
          ngod = GameObject.Find(fileLocation + "NgodInfo");
          sdem = GameObject.Find(fileLocation + "SdemInfo");
          if (yabba.activeInHierarchy)
              print("Accepted YabbaDabbaDoo's listing");
          else if (ngod.activeInHierarchy)
              print("Accepted NGodofPainM's listing");
          else if (sdem.activeInHierarchy)
              print("Accepted SDemonofTruthM's listing");**/
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
