using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class GetActiveListing : MonoBehaviour
{
    public static string listingGamerTag;
    public static string listingCost;
    GameObject activeListing;
    TextMeshProUGUI listingText;
    List<String> listingInfo = new List<string>();
    

    void Update()
    {
        GetListing();

        SetListing();

    }                                                                                                               //////////ATTEPMTING TO GET LISTING NAME AND COST
    void GetListing()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (gameObject.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                activeListing = gameObject.transform.GetChild(i).gameObject;
            }
        }
    }

    void SetListing()
    {
        if (activeListing != null)
        {
            foreach (Transform child in activeListing.transform)
            {
                listingText = child.GetComponent<TextMeshProUGUI>();
                listingInfo.Add(listingText.text);
            }
            listingGamerTag = listingInfo[0];
            listingCost = listingInfo[1];
            string[] splitCost = listingCost.Split(' ');
            listingCost = splitCost[1];
            
        }
    }
}
