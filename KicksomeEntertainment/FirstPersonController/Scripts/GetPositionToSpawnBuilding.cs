using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPositionToSpawnBuilding : MonoBehaviour
{
    [SerializeField] Vector3 pos;
    public static GameObject sign;

    private void Start()
    {
        pos = gameObject.transform.position;
        sign = gameObject;
    }

    public Vector3 GetPosition()
    {
        return pos;
    }
}
