using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    Animator anim;
    public PlayerMovement pm;
    public static bool isAggro;


    private void Start()
    {
        anim = gameObject.GetComponentInParent<Animator>();
     
    }

    private void Update()
    {
        StartCoroutine(NPCWalk());
    }

    IEnumerator NPCWalk()
    {
        yield return new WaitForSeconds(14.2f);
        isAggro = true;
    }
}
