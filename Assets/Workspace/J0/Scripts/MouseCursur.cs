using UnityEngine;

namespace ArmadaInvencible.J0
{
    public class MouseCursur : MonoBehaviour
    {
        public static Vector3 mousePos;

        // ���콺 Ŀ�� ��ġ
        public static Vector3 UpdateMousePosition()
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            return mousePos;
        }
    }
}