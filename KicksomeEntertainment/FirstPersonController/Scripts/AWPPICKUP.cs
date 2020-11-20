using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AWPPICKUP : MonoBehaviour
{
    public GameObject sniper;
    public GameObject targetPractice;
    public GameObject draganov;
    void OnTriggerEnter()
    {
       // Destroy(gameObject);
        sniper.SetActive(true);
        targetPractice.SetActive(true);
        draganov.SetActive(false);

    }
}
