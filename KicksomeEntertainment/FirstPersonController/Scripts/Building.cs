using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[System.Serializable]
public class Building
{
    public string name;
    public float xPosition;
    public float yPosition;
    public float zPosition;
    public float yRotation;

    public Building(string name, float xPosition, float yPosition, float zPosition, float yRotation)
    {
        this.name = name;
        this.xPosition = xPosition;
        this.yPosition = yPosition;
        this.zPosition = zPosition;
        this.yRotation = yRotation;
    }
}

