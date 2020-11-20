using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class MoveDrugsSystem : MonoBehaviour
{
    public ToggleGroup facilityGroup;
    public ToggleGroup warehouseGroup;
    TextMeshProUGUI facilityText;
    TextMeshProUGUI warehouseText;


    public void ActiveToggle()
    {
        Toggle facilityToggle = facilityGroup.ActiveToggles().FirstOrDefault();
        Toggle warehouseToggle = warehouseGroup.ActiveToggles().FirstOrDefault();
        facilityText = facilityToggle.GetComponentInChildren<TextMeshProUGUI>();
        warehouseText = warehouseToggle.GetComponentInChildren<TextMeshProUGUI>();

        print("Picking up drugs from " + facilityText.text + " and delivering them to " + warehouseText.text);

        Cursor.lockState = CursorLockMode.Locked;
        PlayerMovement.playerHasInput = true;
        GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
        StartCoroutine(GiveMuleCollider());
        //call function for mule to go do moving

    }

    public static IEnumerator GiveMuleCollider()
    {
        yield return new WaitForSeconds(5f);
        PlayerMovement.muleCollider.enabled = true;
    }
}
