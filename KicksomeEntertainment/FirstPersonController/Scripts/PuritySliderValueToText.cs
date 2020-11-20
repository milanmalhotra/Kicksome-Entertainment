using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PuritySliderValueToText : MonoBehaviour
{
    public static TextMeshProUGUI purityValue;
    public Slider puritySlider;

    void Start()
    {
        purityValue = GetComponent<TextMeshProUGUI>();
        ShowSliderValuePurity();
    }

    public void ShowSliderValuePurity()
    {
        string purityMessage = puritySlider.value + "%";
        purityValue.text = purityMessage;
    }
}
