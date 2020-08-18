using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enerugi : MonoBehaviour
{
    public LayerMask EnemyMask;
    public LayerMask WallMask;
    public LayerMask FloorMask;
    float Speed = 10f;
    float damage = 1f;

    void FixedUpdate()
    {
        float moveSpeed = Speed * Time.deltaTime;
        CheckCollisions(moveSpeed);
        transform.Translate(Vector3.forward * moveSpeed);
    }

    // E15 8분 52초에서 다시 시작

    void CheckCollisions(float moveSpeed)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, moveSpeed, EnemyMask, QueryTriggerInteraction.Collide))
            OnHitObject(hit.collider,hit.point);
        if (Physics.Raycast(ray, out hit, moveSpeed, WallMask, QueryTriggerInteraction.Collide))
            OnHitObject(hit.collider, hit.point);
        if (Physics.Raycast(ray, out hit, moveSpeed, FloorMask, QueryTriggerInteraction.Collide))
            OnHitObject(hit.collider, hit.point);
    }

    void OnHitObject(Collider c, Vector3 hitPoint)
    {
        IDamage damageAbleObject = c.GetComponent<IDamage>();
        if (damageAbleObject != null)
        {
            damageAbleObject.TakeHit(damage);
        }
        GameObject.Destroy(gameObject);
    }
}
