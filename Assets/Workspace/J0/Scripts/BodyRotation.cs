/* 
 * 작성자: 이재영
 * 수정 날짜: 25/01/13
 * 수정 및 추가 내용: 
 */

using UnityEngine;

namespace ArmadaInvencible.J0
{
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

        private void Start()
        {
            rotateAngle = transform.rotation;

            // 기본 본체 회전속도 조절
            RotateSpeed = 0.5f;
        }

        private void Update()
        {
            // 임시 속도 설정
            RotateAngle(RotateSpeed);
        }

        // 본체 회전
        private void RotateAngle(float rotateSpeed)
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
}