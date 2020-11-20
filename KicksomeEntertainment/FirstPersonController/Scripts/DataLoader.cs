using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using UnityEditor.PackageManager;
using UnityEngine;

[System.Serializable]
public class DataLoader : MonoSingleton<DataLoader>
{
    public List<Building> buildingList = new List<Building>();
    public TextAsset jsonFile;
    string buildings;
    public List<Building> test = new List<Building>();
    public Buildings buildingsInJson;

    public List<Building> ImportBuildingDataFromJson()
    {
        buildingsInJson = JsonUtility.FromJson<Buildings>(jsonFile.text);
        
        foreach(Building building in buildingsInJson.buildings)
        {
            buildingList.Add(building);
        }
        return buildingList;
    }

    public void SaveBuildingDataToJson()
    {
        Buildings buildingsToJson = new Buildings();
        buildingsToJson.buildings = buildingList.ToArray();

        File.WriteAllText(Application.dataPath + "/jsonFile.json", JsonUtility.ToJson(buildingsToJson));
        Debug.Log(JsonUtility.ToJson(buildingsToJson, true));
        
        print("saved");
    }
    
    
    public void AddBuildingToList(Building building)
    {
        buildingList.Add(building);
    }
}
