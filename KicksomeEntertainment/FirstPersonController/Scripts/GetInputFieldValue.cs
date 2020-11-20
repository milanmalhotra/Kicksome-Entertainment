using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GetInputFieldValue : MonoBehaviour
{
    public static string priceValue;

    // Start is called before the first frame update
    void Start()
    {
        var input = gameObject.GetComponent<TMP_InputField>();
        var submitEvent = new TMP_InputField.SubmitEvent();
        submitEvent.AddListener(SubmitName);
        input.onEndEdit = submitEvent;
    }

    void SubmitName(string value)
    {
        priceValue = value;
    }
}
