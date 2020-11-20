using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public GameObject pickup;
    Vector3 position = new Vector3(0f, 0f, 2f);

    public void ReplaceItem(Item item)
    {
        GameObject player = GameObject.Find("FirstPersonPlayer");
        GameObject droppedItem = item.GetGameObject();
        droppedItem.transform.position = player.transform.position + position;
        droppedItem.SetActive(true);
    }

    public void SetGameObject(GameObject GO)
    {
        pickup = GO;
    }

    public GameObject GetGameObject()
    {
        return pickup;
    }
}
