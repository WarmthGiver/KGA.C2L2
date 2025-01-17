/* 
 * 작성자: 이재영
 * 수정 날짜: 25/01/13
 * 수정 및 추가 내용: 
 */
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public sealed class BodyRotation : MonoBehaviour
{
    private Quaternion rotateAngle;

    [SerializeField] 
    private float _rotateSpeed;

    public float RotateSpeed
    {
        get { return _rotateSpeed; }
        private set { _rotateSpeed = value; }
    }

    void Start()
    {
        rotateAngle = transform.rotation;
        RotateSpeed = 0.07f; // 기본 본체 회전속도 조절
    }

    void Update()
    {
        RotateAngle(RotateSpeed); // 임시 속도 설정
    }

    // 본체 회전
    void RotateAngle(float rotateSpeed)
    {
        transform.rotation = rotateAngle;

        if (Input.GetKey(KeyCode.A))
        {
            rotateAngle = Quaternion.Euler(rotateAngle.eulerAngles + new Vector3(0, 0, rotateSpeed));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rotateAngle = Quaternion.Euler(rotateAngle.eulerAngles + new Vector3(0, 0, -rotateSpeed));
        }
    }
}
