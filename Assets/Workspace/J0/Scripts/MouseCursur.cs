using UnityEngine;

namespace ArmadaInvencible.J0
{
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
}