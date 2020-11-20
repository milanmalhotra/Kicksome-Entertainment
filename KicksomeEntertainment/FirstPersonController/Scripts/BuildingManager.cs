using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoSingleton<BuildingManager>
{
    public void PlaceBuildings(List<Building> buildings)
    {
        foreach (Building building in buildings)
        {
            GameObject.Instantiate(Resources.Load(building.name), 
                new Vector3(building.xPosition, building.yPosition, building.zPosition), 
                Quaternion.Euler(0, building.yRotation, 0));
        }
    }
}
