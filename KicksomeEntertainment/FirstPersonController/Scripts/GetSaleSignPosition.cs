using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSaleSignPosition : MonoSingleton<GetSaleSignPosition>
{
    public GameObject sign;
    public Vector3 test;
    public Vector3 Position()
    {
        test = sign.transform.position;
        return test;
    }
}
