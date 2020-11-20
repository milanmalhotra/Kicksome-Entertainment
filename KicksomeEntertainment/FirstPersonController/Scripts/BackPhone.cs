using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.EventSystems;

public class BackPhone : MonoBehaviour
{
    public GameObject homeScreen;
    public GameObject defaultButton;
    public EventSystem eventSystem;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            eventSystem.SetSelectedGameObject(null);
            gameObject.SetActive(false);
            homeScreen.SetActive(true);
            eventSystem.SetSelectedGameObject(defaultButton);
        }
    }
}
