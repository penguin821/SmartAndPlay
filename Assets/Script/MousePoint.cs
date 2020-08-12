using UnityEngine;
using System.Collections;

public class MousePoint : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        if (Input.GetMouseButton(0))  // 마우스가 클릭 되면
        {
            Vector3 mos = Input.mousePosition;
            mos.z = Camera.main.farClipPlane; // 카메라가 보는 방향과, 시야를 가져온다.

            Vector3 dir = Camera.main.ScreenToWorldPoint(mos);
            // 월드의 좌표를 클릭했을 때 화면에 자신이 보고있는 화면에 맞춰 좌표를 바꿔준다.

            RaycastHit hit;
            if (Physics.Raycast(transform.position, dir, out hit, mos.z))
            {
                target.position = hit.point; // 타겟을 레이캐스트가 충돌된 곳으로 옮긴다.
            }
        }
    }
}