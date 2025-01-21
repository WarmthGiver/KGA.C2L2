using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    protected Rigidbody2D rigidBD;
    // 중심 좌표
    protected Vector3 center = new Vector3(0, 0, 0);

    protected void Start()
    {
        FacingParallel();
    }

    protected virtual void Update()
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

    // 함선 기준 방향벡터
    protected Vector3 MainDirectionVector()
    {
        return center - MouseCursur.UpdateMousePosition();
    }

    // 무기 기준 방향벡터
    protected Vector3 WeaponDirectionVector()
    {
        return gameObject.transform.position - MouseCursur.UpdateMousePosition();
    }

    // 마우스 커서 향하도록
    protected float AngleCalculator(Vector3 facingTo)
    {
        // (설명)방향벡터와 아크탄젠트를 사용해서 변화 각을 알아낸 다음 라디안값으로 변환시킴.
        return Mathf.Atan2(facingTo.y, facingTo.x) * Mathf.Rad2Deg + 90;
    }

    // 메인 방향벡터 바라보기(평행 공격)
    protected void FacingParallel()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, AngleCalculator(MainDirectionVector()));
    }

    // 마우스 커서 바라보기(집중 공격)
    protected void FacingCursur()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, AngleCalculator(WeaponDirectionVector()));
    }
}
