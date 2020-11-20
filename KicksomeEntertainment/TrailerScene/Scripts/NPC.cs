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
    /*private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "CM vcam3")
        {
            anim.SetTrigger("Walking");
            isAggro = true;
            //pm.TakePlayerControlAway();
            GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
            PlayerMovement.playerHasInput = false;
          
        }
        else
        {
            anim.SetTrigger("Idle");
            
        }
        
    }*/

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
