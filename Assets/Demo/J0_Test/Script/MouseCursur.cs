using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursur : MonoBehaviour
{
    public static Vector3 mousePos;

    // 마우스 커서 위치
    public static Vector3 UpdateMousePosition()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePos;
    }
}
