using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enerugi : MonoBehaviour
{
    public Transform target;

    [SerializeField]
    private GameObject hitEffect;

    public LayerMask EnemyMask;
    public LayerMask WallMask;
    public LayerMask FloorMask;
    float Speed = 0.01f;
    float damage = 1f;

    void FixedUpdate()
    {
        Vector3 mos = Input.mousePosition;
        mos.z = Camera.main.farClipPlane; // 카메라가 보는 방향과, 시야를 가져온다.

        Vector3 dir = Camera.main.ScreenToWorldPoint(mos);
        // 월드의 좌표를 클릭했을 때 화면에 자신이 보고있는 화면에 맞춰 좌표를 바꿔준다.

        float moveSpeed = Speed * Time.deltaTime;
        CheckCollisions(moveSpeed);
        transform.Translate(dir * moveSpeed);

        Debug.Log(mos);
        Debug.Log(dir);

    }

    void CheckCollisions(float moveSpeed)
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, moveSpeed, EnemyMask, QueryTriggerInteraction.Collide))
            OnHitObject(hit);
        if (Physics.Raycast(ray, out hit, moveSpeed, WallMask, QueryTriggerInteraction.Collide))
            OnHitObject(hit);
        if (Physics.Raycast(ray, out hit, moveSpeed, FloorMask, QueryTriggerInteraction.Collide))
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

    //void OnCollisionEnter(Collision other)
    //{
    //    ContactPoint contactPoint = other.contacts[0];

    //    var clone = Instantiate(hitEffect, contactPoint.point, Quaternion.LookRotation(contactPoint.normal));

    //    Destroy(clone, 0.5f);
    //    Destroy(gameObject);
    //}
}
