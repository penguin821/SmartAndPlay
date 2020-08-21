using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbController : MonoBehaviour
{
    public Transform orbHold;
    public Orb startingOrb;
    Orb equippedOrb;

    void Start()
    {
        if (startingOrb != null)
        {
            EquipOrb(startingOrb);
        }
    }

    public void EquipOrb(Orb orbToEquip)
    {
        if (equippedOrb != null)
        {
            Destroy(equippedOrb.gameObject);
        }
        equippedOrb = Instantiate(orbToEquip,orbHold.position,orbHold.rotation) as Orb;
        equippedOrb.transform.parent = orbHold;
    }

    public void Shoot()
    {
        if (equippedOrb != null)
            equippedOrb.Shoot();
    }
}
