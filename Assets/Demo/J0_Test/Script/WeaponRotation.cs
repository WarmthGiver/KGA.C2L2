using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class WeaponRotation : MonoBehaviour
{
    // ���콺 ��ǥ
    Vector3 mousePos;

    Rigidbody2D rigidBD;
    // �߽� ��ǥ
    Vector3 center = new Vector3(0, 0, 0);

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

    // ���콺 Ŀ�� ��ġ
    Vector3 UpdateMousePosition()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePos;
    }

    // �Լ� ���� ���⺤��
    Vector3 MainDirectionVector()
    {
        return center - UpdateMousePosition();
    }

    // ���� ���� ���⺤��
    Vector3 SideDirectionVector()
    {
        return gameObject.transform.position - UpdateMousePosition();
    }

    // ���콺 Ŀ�� ���ϵ���
    public float AngleCalculator(Vector3 facingTo)
    {
        // (����)���⺤�Ϳ� ��ũź��Ʈ�� ����ؼ� ��ȭ ���� �˾Ƴ� ���� ���Ȱ����� ��ȯ��Ŵ.
        return Mathf.Atan2(facingTo.y, facingTo.x) * Mathf.Rad2Deg + 90;
    }

    // ���� ���⺤�� �ٶ󺸱�(���� ����)
    public void FacingParallel()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, AngleCalculator(MainDirectionVector()));
    }

    // ���콺 Ŀ�� �ٶ󺸱�(���� ����)
    public void FacingCursur()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, AngleCalculator(SideDirectionVector()));
    }
}
