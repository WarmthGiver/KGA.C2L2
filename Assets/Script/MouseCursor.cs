/* 
 * �ۼ���: ���翵
 * ���� ��¥: 25/01/13
 * ���� �� �߰� ����: 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    Vector3 mousePos;

    Vector3 center;

    // ���⺤�� ����ƽ ����
    public static Vector3 directionVec;

    void Start()
    {
        center = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        mousePos = Input.mousePosition;
        directionVec = mousePos - center;
    }

    void Update()
    {
        mousePos = Input.mousePosition;
        directionVec = mousePos - center;
    }
}
