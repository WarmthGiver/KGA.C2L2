/* 작성자 : 최현민
 * 날짜 25 - 1 - 20
 * 계산식 쓰는 싱글톤
*/

using UnityEngine;

namespace ArmadaInvencible.CHM
{
    public static class Utils// 각도 계산하는 싱글톤만듬
    {
        public static Quaternion LookTaget(Vector2 start, Vector2 end)
        {
            var look = GetAngleFromPosition(start, end);

            Quaternion taget = Quaternion.Euler(0f, 0f, look-90);

            return taget;
        }

        //매개변수로 받아온 두 점 정보를 바탕으로 각도를 구하는 기능의 메서드
        public static float GetAngleFromPosition(Vector2 owner, Vector2 targer)
        {
            //원점으로 부터의 거리와 수평축으로 부터의 각도를 이용해 위치를 구하는 극 좌표계 이용
            //각도 = arctan(y/x)
            // x , y 변위값 구하기
            float dx = targer.x - owner.x;

            float dy = targer.y - owner.y;

            // x, y 변위값을 바탕으로 각도 구하기
            //각도가 radian 단위 이기 때문에 Mathf.Rad2Deg를 곱해 도 단위를 구함
            float degree = Mathf.Atan2(dy,dx)*Mathf.Rad2Deg;

            return degree;            
        }
        
        /// <summary>
        /// degree 값을 radian 값으로 변환하는 메서드
        /// 1도는 "PI / 180" radian
        /// angle도 는 "\PI / 180 * angle" radian
        /// </summary>       
        public static float DegreeToRadian(float angle)
        {
            return Mathf.PI * angle / 180;
        }

        /// <summary>
        /// 원의 둘레 위치를 구하는 메서드
        /// </summary>
        /// <param name="start">시작점</param>
        /// <param name="angle">각도</param>
        /// <param name="r">반지름</param>
        /// <returns></returns>
        public static Vector2 GetCirclePoint(Vector3 start, float angle, float r)
        {
            //디그리 각도 값을 라디안으로 변경
            angle = DegreeToRadian(angle);

            //원점(월드 좌표 ?)을 기준으로 x, y 좌표를 구하기 때문에 시작지점 좌표(start) 를 더해준다
            Vector2 position = Vector2.zero;

            position.x = Mathf.Cos(angle)* r + start.x;

            position.y = Mathf.Sin(angle)* r + start.y;

            return position;
        }

        //시작 , 목표 위치 사이의 t 지점위치에 대한 보간  값을 반환 하는 메서드
        public static Vector2 Lerp(Vector2 a, Vector2 b, float t)
        {
            return a + (b - a) * t;
        }

        /// <summary>
        /// 시작 목표 위치 사이의 1개의 점 정보를 추가해
        /// 곡선(2차 방정식)형태로 보간하는 메서드
        /// </summary>
        /// <param name="a">시작</param>
        /// <param name="b">목표</param>
        /// <param name="c">시작 목표 사이의 중간점</param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Vector2 QuadraticCurve(Vector2 a, Vector2 b, Vector2 c, float t)
        {
            Vector2 p1 = Lerp(a, b, t);

            Vector2 p2 = Lerp(b, c, t);

            return Lerp(p1, p2, t);
        }

        /// <summary>
        /// 시작 목표 위치사이에 점 2개 추가해
        /// 3차방정식 곡선 형태로 보간하는 메서드
        /// </summary>
        /// <param name="a">시작</param>
        /// <param name="b">시작,목표 사이의 점 1</param>
        /// <param name="c">시작,목표 사이의 점 2</param>
        /// <param name="d">목표</param>
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