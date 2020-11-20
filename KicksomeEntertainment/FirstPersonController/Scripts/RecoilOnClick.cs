using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilOnClick : MonoBehaviour
{
    [Header("Make the curve domains from 0 to 1.")]
    [Header("Output value is degrees of deflection.")]
    [Header("Adjust time interval separately below.")]
    public AnimationCurve RecoilUp;
    public AnimationCurve RecoilRight;

    [Header("How long is entire recoil sequence?")]
    float TimeInterval = 0.3f;

    [Header("Which object is having its .localRotation driven.")]
    public Transform RecoilPivot;

    float recoiling;

    void DriveRecoil(float fraction)
    {
        float up = RecoilUp.Evaluate(fraction);
        float right = RecoilRight.Evaluate(fraction);

        // special number to FORCE you to have zero output when fraction is zero,
        // to keep you from making borked curves and wondering WTF.
        if (fraction == 0)
        {
            up = 0;
            right = 0;
        }

        up = -up;

        RecoilPivot.localRotation = Quaternion.Euler(up, right, 0);
    }

    public void Test()
    {
        if (recoiling == 0)
        {
            if (Input.GetButtonDown("Fire1") && Gun.isScoped && Time.time >= Gun.nextTimeToFire)
            {
                recoiling = Time.deltaTime;
            }
        }

        if (recoiling > 0)
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
    }
}
