using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLineOfBuildings : MonoBehaviour
{

    public GameObject building;
    float posX;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.O))
        {
            for (int i = 0; i < 6; i++)
            {
                posX = 13;
                StartCoroutine(InstantiateBuildings());
            }
        }
        
    }

    IEnumerator InstantiateBuildings()
    {
        yield return new WaitForSeconds(.5f);
        Instantiate(building, new Vector3(posX, 0, -9.18f), Quaternion.identity);
        posX += 10;
    }
}
