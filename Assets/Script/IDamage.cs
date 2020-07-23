using System.Collections;
using UnityEngine;

public interface IDamage
{
    void TakeHit(float damage, RaycastHit hit);
}
