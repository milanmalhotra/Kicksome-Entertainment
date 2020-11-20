 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnBuildings : MonoBehaviour
{  
    void Start()
    {
        BuildingManager.Instance.PlaceBuildings(DataLoader.Instance.ImportBuildingDataFromJson());
        DMMap.instance.Generate();

    }
    
}
