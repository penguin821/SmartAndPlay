using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public Transform muzzle;
    public Enerugi enerugi;
    public float msBetweenShots = 100;
    public float muzzleVelocity = 35;

    float nextShotTime;

    public void Shoot()
    {
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 1000;
            Enerugi newEnerugi = Instantiate(enerugi, muzzle.position, muzzle.rotation) as Enerugi;
            newEnerugi.SetSpeed(muzzleVelocity);
        }
    }
}
