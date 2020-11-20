using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderValueToText : MonoBehaviour
{
    public Slider quantitySlider;
    
    public static TextMeshProUGUI sliderValue;
    
    void Start()
    {
        sliderValue = GetComponent<TextMeshProUGUI>();
        
        ShowSliderValue();
        
    }

    public void ShowSliderValue()
    {
        string sliderMessage = quantitySlider.value + "g";
        sliderValue.text = sliderMessage;
    }

   
    
}
