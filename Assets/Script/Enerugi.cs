using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enerugi : MonoBehaviour
{
    public LayerMask EnemyMask;
    public LayerMask WallMask;
    float Speed = 10f;
    float damage = 1f;

    void FixedUpdate()
    {
        float moveSpeed = Speed * Time.deltaTime;
        CheckCollisions(moveSpeed);
        transform.Translate(Vector3.forward * moveSpeed);
    }

    void CheckCollisions(float moveSpeed)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, moveSpeed, EnemyMask, QueryTriggerInteraction.Collide))
            OnHitObject(hit);
        if (Physics.Raycast(ray, out hit, moveSpeed, WallMask, QueryTriggerInteraction.Collide))
            OnHitObject(hit);
    }

    void OnHitObject(RaycastHit hit)
    {
        IDamage damageAbleObject = hit.collider.GetComponent<IDamage>();
        if (damageAbleObject != null)
        {
            damageAbleObject.TakeHit(damage, hit);
        }
        GameObject.Destroy(gameObject);
    }
}
