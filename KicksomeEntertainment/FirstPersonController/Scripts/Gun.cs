using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    //Sniper
    [Header("Sniper")]
    public float damage = 50f;
    float range = 100f;
    public float fireRate = 5.5f;
    public int maxAmmo = 5;
    int currentAmmo;
    bool isReloading = false;
    public float reloadTime = 2.5f;
    float bloom = 200f;
    float normalFOV;
    public float scopedFOV = 5f;
    Vector3 raycastDir;

    public Camera fpsCam;
    public GameObject weaponCam;
    [Space(10)]
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    [Space(10)]
    public Animator animator;
    public GameObject scopeOverlay;
    [Space(10)]
    public AudioSource gunShot;
    public AudioSource gunCock;
    public AudioSource gunReload;
    public static float nextTimeToFire;
    public static bool isScoped = false;
    
    //Recoil
    [Header("Recoil")]
    public AnimationCurve RecoilUp;
    public AnimationCurve RecoilRight;
    public Transform RecoilPivot;
    float recoiling;
    float TimeInterval = 0.3f;
    [Space(10)]
    public GameObject targets;

    void Start()
    {
        currentAmmo = maxAmmo;
        normalFOV = fpsCam.fieldOfView;
    }
    void Update()
    {
        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time +  7f / fireRate;
            Shoot();
            animator.SetBool("hasShot", true);
            StartCoroutine("EndRecoil");
            if (isScoped)
            {
                recoiling = Time.deltaTime;
            }
        
        }
        if(recoiling > 0)
        {
            float fraction = recoiling / TimeInterval;

            recoiling += Time.deltaTime;
            if (recoiling > TimeInterval)
            {
                recoiling = 0;
                fraction = 0;            // return to time = 0
            }

            DriveRecoil(fraction);
        }
        
        if (Input.GetButtonDown("Fire2"))
        {
            StartCoroutine("OnScoped");
        }

        else if (Input.GetButtonUp("Fire2"))
        {
            StopCoroutine("OnScoped");
            Unscoped();
        }
        
        if (Input.GetKeyDown(KeyCode.R) && currentAmmo < maxAmmo)
            StartCoroutine(Reload());
    }

    void DriveRecoil(float fraction)
    {
        float up = RecoilUp.Evaluate(fraction);
        float right = RecoilRight.Evaluate(fraction);

        if (fraction == 0)
        {
            up = 0;
            right = 0;
        }

        up = -up;

        RecoilPivot.localRotation = Quaternion.Euler(up, right, 0);
    }
    void Shoot()
    {
        muzzleFlash.Play();
        StartCoroutine(GunShot());
        currentAmmo--;
        if (isScoped)
            raycastDir = fpsCam.transform.forward;
        else
        {
            raycastDir = fpsCam.transform.position + fpsCam.transform.forward * 1000f;
            raycastDir += Random.Range(-bloom, bloom) * fpsCam.transform.up;
            raycastDir += Random.Range(-bloom, bloom) * fpsCam.transform.right;
            raycastDir.Normalize();
        }
            
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, raycastDir, out hit, range))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGO, 1.5f);
            //Just for fun //
            if (hit.collider.tag == "StartTarget")
            {
                targets.SetActive(true);
            }
            //End fun //
        }
    }

    IEnumerator OnScoped()
    {
        isScoped = true;
        animator.SetBool("isScoped", isScoped);
        yield return new WaitForSeconds(.25f);
        scopeOverlay.SetActive(true);
        weaponCam.SetActive(false);
        fpsCam.fieldOfView = scopedFOV;
    }

    void Unscoped()
    {
        scopeOverlay.SetActive(false);
        isScoped = false;
        animator.SetBool("isScoped", isScoped);
        weaponCam.SetActive(true);
        fpsCam.fieldOfView = normalFOV;
    }

    IEnumerator EndRecoil()
    {
        yield return new WaitForSeconds(.1f);
        animator.SetBool("hasShot", false);
    }

    IEnumerator Reload()
    {
        recoiling = 0;
        gunReload.Play();
        if (isScoped)
        {
            Unscoped();
            animator.SetBool("isScoped", false);
        }
        animator.SetBool("hasShot", false);
        isReloading = true;
        animator.SetBool("isReloading", true);
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
        animator.SetBool("isReloading", false);
        isScoped = false;
    }

    IEnumerator GunShot()
    {
        gunShot.Play();
        yield return new WaitForSeconds(.2f);
        if(!isReloading && gameObject.tag == "BoltAction")
            gunCock.Play();
    }
}
