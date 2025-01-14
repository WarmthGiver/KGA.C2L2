/* 
 * 작성자: 이재영
 * 수정 날짜: 25/01/13
 * 수정 및 추가 내용: 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    Vector3 mousePos;

    Vector3 center;

    // 방향벡터 스태틱 선언
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
