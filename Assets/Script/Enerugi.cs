using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enerugi : MonoBehaviour
{
    public LayerMask collisionMask;

    //public LayerMask EnemyMask;
    //public LayerMask WallMask;
    //public LayerMask FloorMask;
    float speed = 10;
    float damage = 1;

    float lifetime = 3;
    float skinWidth = 0.1f;

    void Start()
    {
        Destroy(gameObject, lifetime);

        Collider[] initialCollisions = Physics.OverlapSphere(transform.position, .1f, collisionMask);
        if (initialCollisions.Length > 0)
        {
            OnHitObject(initialCollisions[0], transform.position);
        }
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    void Update()
    {
        float moveDistance = speed * Time.deltaTime;
        CheckCollisions(moveDistance);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void CheckCollisions(float moveDistance)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, moveDistance, collisionMask, QueryTriggerInteraction.Collide))
        {
            OnHitObject(hit.collider,hit.point);
        }
    }

    void OnHitObject(Collider c, Vector3 hitPoint)
    {
        IDamage damageableObject = c.GetComponent<IDamage>();
        if (damageableObject != null)
        {
            damageableObject.TakeHit(damage,hitPoint,transform.forward);
        }
        GameObject.Destroy(gameObject);
    }
}

//if (Physics.Raycast(ray, out hit, moveDistance, EnemyMask, QueryTriggerInteraction.Collide))
//{
//    OnHitObject(hit);
//}
//if (Physics.Raycast(ray, out hit, moveDistance, WallMask, QueryTriggerInteraction.Collide))
//{
//    OnHitObject(hit);
//}
//if (Physics.Raycast(ray, out hit, moveDistance, FloorMask, QueryTriggerInteraction.Collide))
//{
//    OnHitObject(hit);
//}