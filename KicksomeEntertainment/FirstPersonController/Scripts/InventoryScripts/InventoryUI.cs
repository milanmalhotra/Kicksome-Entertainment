using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;
    public GameObject inventoryUI;
    public EventSystem eventSystem;
    public GameObject topSlot;
    Inventory inventory;

    public static bool isInventoryActive;

    InventorySlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        isInventoryActive = false;
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && PlayerMovement.playerHasInput)
        {
            isInventoryActive = true;
            inventoryUI.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
        if(Input.GetKeyDown(KeyCode.B) && isInventoryActive)
        {
            isInventoryActive = false;
            inventoryUI.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
