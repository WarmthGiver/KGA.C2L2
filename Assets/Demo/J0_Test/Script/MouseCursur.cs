using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursur : MonoBehaviour
{
    public static Vector3 mousePos;

    void Update()
    {
        
    }
    // ���콺 Ŀ�� ��ġ
    public static Vector3 UpdateMousePosition()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePos;
    }
}
