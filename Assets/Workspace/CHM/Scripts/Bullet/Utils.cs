/* �ۼ��� : ������
 * ��¥ 25 - 1 - 20
 * ���� ���� �̱���
*/

using UnityEngine;

namespace ArmadaInvencible.CHM
{
    public static class Utils// ���� ����ϴ� �̱��游��
    {
        public static Quaternion LookTaget(Vector2 start, Vector2 end)
        {
            var look = GetAngleFromPosition(start, end);

            Quaternion taget = Quaternion.Euler(0f, 0f, look-90);

            return taget;
        }

        //�Ű������� �޾ƿ� �� �� ������ �������� ������ ���ϴ� ����� �޼���
        public static float GetAngleFromPosition(Vector2 owner, Vector2 targer)
        {
            //�������� ������ �Ÿ��� ���������� ������ ������ �̿��� ��ġ�� ���ϴ� �� ��ǥ�� �̿�
            //���� = arctan(y/x)
            // x , y ������ ���ϱ�
            float dx = targer.x - owner.x;

            float dy = targer.y - owner.y;

            // x, y �������� �������� ���� ���ϱ�
            //������ radian ���� �̱� ������ Mathf.Rad2Deg�� ���� �� ������ ����
            float degree = Mathf.Atan2(dy,dx)*Mathf.Rad2Deg;

            return degree;            
        }
        
        /// <summary>
        /// degree ���� radian ������ ��ȯ�ϴ� �޼���
        /// 1���� "PI / 180" radian
        /// angle�� �� "\PI / 180 * angle" radian
        /// </summary>       
        public static float DegreeToRadian(float angle)
        {
            return Mathf.PI * angle / 180;
        }

        /// <summary>
        /// ���� �ѷ� ��ġ�� ���ϴ� �޼���
        /// </summary>
        /// <param name="start">������</param>
        /// <param name="angle">����</param>
        /// <param name="r">������</param>
        /// <returns></returns>
        public static Vector2 GetCirclePoint(Vector3 start, float angle, float r)
        {
            //��׸� ���� ���� �������� ����
            angle = DegreeToRadian(angle);

            //����(���� ��ǥ ?)�� �������� x, y ��ǥ�� ���ϱ� ������ �������� ��ǥ(start) �� �����ش�
            Vector2 position = Vector2.zero;

            position.x = Mathf.Cos(angle)* r + start.x;

            position.y = Mathf.Sin(angle)* r + start.y;

            return position;
        }

        //���� , ��ǥ ��ġ ������ t ������ġ�� ���� ����  ���� ��ȯ �ϴ� �޼���
        public static Vector2 Lerp(Vector2 a, Vector2 b, float t)
        {
            return a + (b - a) * t;
        }

        /// <summary>
        /// ���� ��ǥ ��ġ ������ 1���� �� ������ �߰���
        /// �(2�� ������)���·� �����ϴ� �޼���
        /// </summary>
        /// <param name="a">����</param>
        /// <param name="b">��ǥ</param>
        /// <param name="c">���� ��ǥ ������ �߰���</param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Vector2 QuadraticCurve(Vector2 a, Vector2 b, Vector2 c, float t)
        {
            Vector2 p1 = Lerp(a, b, t);

            Vector2 p2 = Lerp(b, c, t);

            return Lerp(p1, p2, t);
        }

        /// <summary>
        /// ���� ��ǥ ��ġ���̿� �� 2�� �߰���
        /// 3�������� � ���·� �����ϴ� �޼���
        /// </summary>
        /// <param name="a">����</param>
        /// <param name="b">����,��ǥ ������ �� 1</param>
        /// <param name="c">����,��ǥ ������ �� 2</param>
        /// <param name="d">��ǥ</param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Vector2 CubicCurve(Vector2 a, Vector2 b, Vector2 c, Vector2 d, float t)
        {
            Vector2 p1 = QuadraticCurve(a, b, c, t);

            Vector2 p2 = QuadraticCurve(b,c,d,t);

            return Lerp(p1,p2,t);
        }
    }
}