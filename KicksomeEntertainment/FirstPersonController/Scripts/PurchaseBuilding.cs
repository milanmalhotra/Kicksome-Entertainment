using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class PurchaseBuilding : MonoSingleton<PurchaseBuilding>
{
    //public GameObject saleSign;
    
    string selectedBuilding;
    Vector3 pos;
    public GameObject sign;
    GameObject myBuilding;
    public GameObject shack;
    
    public void SelectBuilding()
    {
        
        var selectedButton = EventSystem.current.currentSelectedGameObject.name;
      
        if (selectedButton == "Button")
        {
            selectedBuilding = "BlueBuilding";
        }
        else if(selectedButton == "Button (1)")
        {
            selectedBuilding = "RedBuilding";
        }
        else if(selectedButton == "Button (2)")
        {
            selectedBuilding = "YellowBuilding";
        }
        Vector3 offset = new Vector3(-10, 0, 0);
        if (selectedBuilding == "YellowBuilding")
        {
            offset = new Vector3(-10, 10, 0);
        }
        pos = PlayerMovement.spawnPosition + offset;
        myBuilding = Instantiate(Resources.Load(selectedBuilding), (pos), Quaternion.identity) as GameObject;
        
        PlayerMovement.saleSign.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
        PlayerMovement.playerHasInput = true;
        PlayerMovement.inMenu = false;

        Building purchased = new Building(selectedBuilding, pos.x, pos.y, pos.z, 0);
        if (purchased.name != null)
            DataLoader.Instance.AddBuildingToList(purchased);

        var buildingList = DataLoader.Instance.buildingList;

        for(int i = 0; i < buildingList.Count; i++)
        {
            if(buildingList[i].name + "(Clone)" == PlayerMovement.hello.name)
            {
                Destroy(GameObject.Find(buildingList[i].name + "(Clone)"));
                buildingList.Remove(buildingList[i]);
                
            }
        }
        StartCoroutine(Test());
    }
  
    public void Exit()
    {
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
        PlayerMovement.playerHasInput = true;
        PlayerMovement.inMenu = false;
    }

    public void SavePurchasedBuildingData()
    {
        Building purchased = new Building(selectedBuilding, myBuilding.transform.position.x, pos.y, pos.z, 0);
        if(purchased.name != null)
            DataLoader.Instance.AddBuildingToList(purchased);
    }


    IEnumerator Test()
    {
        yield return new WaitForSeconds(.1f);
        DMMap.instance.Generate();
    }
}
