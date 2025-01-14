/* 
 * �ۼ���: ���翵
 * ���� ��¥: 25/01/13
 * ���� �� �߰� ����: 
 */
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BodyRotation : MonoBehaviour
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
        RotateSpeed = 0.1f; // �⺻ ��ü ȸ���ӵ� ����
    }

    void Update()
    {
        RotateAngle(RotateSpeed); // �ӽ� �ӵ� ����
    }

    // ��ü ȸ��
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
