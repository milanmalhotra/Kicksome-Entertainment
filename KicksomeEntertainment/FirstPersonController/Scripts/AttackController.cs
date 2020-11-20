using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class AttackController : MonoBehaviour
{
    public static bool selectedDistrict;
    public static bool hitmanHasReport;
    PlayerMovement pm;
    public GameObject noReportMessage;
    public GameObject playerList;
    
    void Start()
    {
        pm = GameObject.Find("FirstPersonPlayer").GetComponent<PlayerMovement>();
    }
    public void ClickDistrict()
    {
        var selectedButton = EventSystem.current.currentSelectedGameObject;
        Debug.Log("Going to scout " + selectedButton.GetComponentInChildren<TextMeshProUGUI>().text);
        pm.GivePlayerControl();
        selectedDistrict = true;
        StartCoroutine(Spotting());
    }

    public void CancelSpotter()
    {
        pm.GivePlayerControl();
        PlayerMovement.spotterCollider.enabled = true;
    }

    public void SendInfoToHitman()
    {
        pm.GivePlayerControl();
        PlayerMovement.spotterCollider.enabled = true;
        hitmanHasReport = true;
        selectedDistrict = false;
        Debug.Log("Sent info to hitman");
    }

    public void CancelHitman()
    {
        pm.GivePlayerControl();
        PlayerMovement.hitmanCollider.enabled = true;
    }

    public void HitmanAttack()
    {
        if (!hitmanHasReport)
            StartCoroutine(NoReport());
        else
            ShowPlayersToAttack();
        
    }

    void ShowPlayersToAttack()
    {
        playerList.SetActive(true);
    }

    public void AttackPlayer()
    {
        pm.GivePlayerControl();
        PlayerMovement.hitmanCollider.enabled = true;
        Debug.Log("Attacking YabbaDabbaDoo");
    }
    IEnumerator NoReport()
    {
        noReportMessage.SetActive(true);
        yield return new WaitForSeconds(3f);
        noReportMessage.SetActive(false);
        PlayerMovement.hitmanCollider.enabled = true;
        pm.GivePlayerControl();
    }
    IEnumerator Spotting()
    {
        yield return new WaitForSeconds(5f);
        PlayerMovement.spotterCollider.enabled = true;
    }
}
