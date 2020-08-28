using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public enum FireMode { Auto,Burst,Single};
    public FireMode fireMode;

    public Transform[] projectileSpawn;
    public Enerugi enerugi;
    public float msBetweenShots = 100;
    public float muzzleVelocity = 35;
    public int burstCount;

    float nextShotTime;

    bool triggerReleasedSinceLastShot;
    int shotRemaining;

    public AudioClip shootAudio;

    void Start()
    {
        shotRemaining = burstCount;
    }

    void Shoot()
    {
        if (Time.time > nextShotTime)
        {
            if(fireMode==FireMode.Burst)
            {
                if (shotRemaining == 0)
                    return;
                shotRemaining--;
            }
            else if (fireMode == FireMode.Single)
            {
                if (!triggerReleasedSinceLastShot)
                    return;
            }

            for (int i = 0; i < projectileSpawn.Length; i++)
            {
                nextShotTime = Time.time + msBetweenShots / 1000;
                Enerugi newEnerugi = Instantiate(enerugi, projectileSpawn[i].position, projectileSpawn[i].rotation) as Enerugi;
                newEnerugi.SetSpeed(muzzleVelocity);
            }

            AudioManager.instance.PlaySound(shootAudio, transform.position);
        }
    }

    public void OnTriggerHold()
    {
        Shoot();
        triggerReleasedSinceLastShot = false;
    }
    public void OnTriggerRelease()
    {
        triggerReleasedSinceLastShot = true;
        shotRemaining = burstCount;
    }
}
