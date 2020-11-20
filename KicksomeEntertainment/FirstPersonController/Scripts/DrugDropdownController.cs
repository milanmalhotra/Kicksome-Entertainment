using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DrugDropdownController : MonoBehaviour
{
    public TMP_Dropdown buyDropdown;
    public TMP_Dropdown sellDropdown;
    public GameObject buyingPage;
    public GameObject sellingPage;
    List<string> drugs = new List<string>() { "Select Drug", "Weed", "Cocaine", "Meth" };
    string selectedName;

    public void DropdownIndexChanged(int index)
    {
        selectedName = drugs[index];
    }
    void Start()
    {
        PopulateList();
    }

    void PopulateList()
    {
        sellDropdown.AddOptions(drugs);
        buyDropdown.AddOptions(drugs);
    }

    public void OnSubmit()
    {
        if (buyingPage.activeInHierarchy)
            print("Posted a listing seeking " + SliderValueToText.sliderValue.text + " of " + selectedName + " for $" + GetInputFieldValue.priceValue + " with a purity of " + PuritySliderValueToText.purityValue.text);
        else if (sellingPage.activeInHierarchy)
            print("Posted a listing selling " + SliderValueToText.sliderValue.text + " of " + selectedName + " for $" + GetInputFieldValue.priceValue + " with a purity of " + PuritySliderValueToText.purityValue.text);
        Cursor.lockState = CursorLockMode.Locked;
        PlayerMovement.playerHasInput = true;
        GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
        PlayerMovement.compCollider.enabled = true;
    }
}
