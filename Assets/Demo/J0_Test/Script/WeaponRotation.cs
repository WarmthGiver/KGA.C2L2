using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class WeaponRotation : MonoBehaviour
{
    // 마우스 좌표
    Vector3 mousePos;

    Rigidbody2D rigidBD;
    // 중심 좌표
    Vector3 center = new Vector3(0, 0, 0);

    private void Start()
    {
        FacingParallel();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            FacingCursur();
        }
        else
        {
            FacingParallel();
        }
    }

    // 마우스 커서 위치
    Vector3 UpdateMousePosition()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePos;
    }

    // 함선 기준 방향벡터
    Vector3 MainDirectionVector()
    {
        return center - UpdateMousePosition();
    }

    // 무기 기준 방향벡터
    Vector3 SideDirectionVector()
    {
        return gameObject.transform.position - UpdateMousePosition();
    }

    // 마우스 커서 향하도록
    public float AngleCalculator(Vector3 facingTo)
    {
        // (설명)방향벡터와 아크탄젠트를 사용해서 변화 각을 알아낸 다음 라디안값으로 변환시킴.
        return Mathf.Atan2(facingTo.y, facingTo.x) * Mathf.Rad2Deg + 90;
    }

    // 메인 방향벡터 바라보기(평행 공격)
    public void FacingParallel()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, AngleCalculator(MainDirectionVector()));
    }

    // 마우스 커서 바라보기(집중 공격)
    public void FacingCursur()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, AngleCalculator(SideDirectionVector()));
    }
}
