using CHM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZL.Unity.Collections;
using ZL.Unity.ObjectPooling;
using static UnityEngine.GraphicsBuffer;

public class BezierCurvesBullet : Bulletbase
{

    //Vector2[] point = new Vector2[4];

    //bool hit = false;

    //[SerializeField][Range(0, 1)] private float t = 0;
    //[SerializeField] public float spd = 5;
    //[SerializeField] public float posA = 0.55f;
    //[SerializeField] public float posB = 0.45f;

    //public GameObject master;
    //public GameObject enemy;

    //void Start()
    //{
    //point[0] = master.transform.position; // P0
    //point[1] = PointSetting(master.transform.position); // P1
    //point[2] = PointSetting(enemy.transform.position); // P2
    //point[3] = enemy.transform.position; // P3
    //}

    //void FixedUpdate()
    //{
    //if (t > 1) return;
    //if (hit) return;
    //t += Time.deltaTime * spd;
    //DrawTrajectory();
    //}

    //Vector2 PointSetting(Vector2 origin)
    //{
    //float x, y;

    //x = posA * Mathf.Cos(Random.Range(0, 360) * Mathf.Deg2Rad)
    //+ origin.x;
    //y = posB * Mathf.Sin(Random.Range(0, 360) * Mathf.Deg2Rad)
    //+ origin.y;
    //return new Vector2(x, y);
    //}

    //void DrawTrajectory()
    //{
    //transform.position = new Vector2(
    //FourPointBezier(point[0].x, point[1].x, point[2].x, point[3].x),
    //FourPointBezier(point[0].y, point[1].y, point[2].y, point[3].y)
    //);
    //}

    //void OnTriggerEnter2D(Collider2D collision)
    //{
    //if (collision.gameObject == enemy)
    //{
    //hit = true;

    //Destroy(gameObject, 0.35f);
    //}
    //}


    //private float FourPointBezier(float a, float b, float c, float d)
    //{
    //return Mathf.Pow((1 - t), 3) * a
    //+ Mathf.Pow((1 - t), 2) * 3 * t * b
    //+ Mathf.Pow(t, 2) * 3 * (1 - t) * c
    //+ Mathf.Pow(t, 3) * d;
    //}
    Vector3[] m_points = new Vector3[4];

    public GameObject m_target;
    private float m_timerMax = 0;
    private float m_timerCurrent = 0;
    private float m_speed;

    public void Init(Transform _startTr, Transform _endTr, float _speed, float _newPointDistanceFromStartTr, float _newPointDistanceFromEndTr)
    {
        
        m_speed = _speed;

        // 끝에 도착할 시간을 랜덤으로 줌.
        m_timerMax = Random.Range(0.8f, 1.0f);

        // 시작 지점.
        m_points[0] = _startTr.position;

        // 시작 지점을 기준으로 랜덤 포인트 지정.
        m_points[1] = _startTr.position +
            (_newPointDistanceFromStartTr * Random.Range(-0.1f, 0.1f) * _startTr.right) + // X (좌, 우 전체)
            (_newPointDistanceFromStartTr * Random.Range(-0.15f, 0.5f) * _startTr.up); //+ // Y (아래쪽 조금, 위쪽 전체)
                                                                                       //(_newPointDistanceFromStartTr * Random.Range(-1.0f, -0.8f) * _startTr.forward); // Z (뒤 쪽만)

        // 도착 지점을 기준으로 랜덤 포인트 지정.
        m_points[2] = _endTr.position +
            (_newPointDistanceFromEndTr * Random.Range(-0.5f, 0.5f) * _endTr.right) + // X (좌, 우 전체)
            (_newPointDistanceFromEndTr * Random.Range(-0.5f, 0.5f) * _endTr.up); //+ // Y (위, 아래 전체)
            //(_newPointDistanceFromEndTr * Random.Range(0.8f, 1.0f) * _endTr.forward); // Z (앞 쪽만)

        // 도착 지점.
        m_points[3] = _endTr.position;

        transform.position = _startTr.position;
    }

    void Update()
    {
        if (m_timerCurrent > m_timerMax)
        {
            return;
        }

        // 경과 시간 계산.
        m_timerCurrent += Time.deltaTime * m_speed;
        transform.rotation = Utils.LookTaget(transform.position, m_target.transform.position);

        // 베지어 곡선으로 X,Y,Z 좌표 얻기.
        transform.position = new Vector3
        (
            CubicBezierCurve(m_points[0].x, m_points[1].x, m_points[2].x, m_points[3].x),
            CubicBezierCurve(m_points[0].y, m_points[1].y, m_points[2].y, m_points[3].y),
            CubicBezierCurve(m_points[0].z, m_points[1].z, m_points[2].z, m_points[3].z)
        );
    }

    /// <summary>
    /// 3차 베지어 곡선.
    /// </summary>
    /// <param name="a">시작 위치</param>
    /// <param name="b">시작 위치에서 얼마나 꺾일 지 정하는 위치</param>
    /// <param name="c">도착 위치에서 얼마나 꺾일 지 정하는 위치</param>
    /// <param name="d">도착 위치</param>
    /// <returns></returns>
    private float CubicBezierCurve(float a, float b, float c, float d)
    {
        // (0~1)의 값에 따라 베지어 곡선 값을 구하기 때문에, 비율에 따른 시간을 구했다.
        float t = m_timerCurrent / m_timerMax; // (현재 경과 시간 / 최대 시간)

        // 방정식.
        /*
        return Mathf.Pow((1 - t), 3) * a
            + Mathf.Pow((1 - t), 2) * 3 * t * b
            + Mathf.Pow(t, 2) * 3 * (1 - t) * c
            + Mathf.Pow(t, 3) * d;
        */

        // 이해한대로 편하게 쓰면.
        float ab = Mathf.Lerp(a, b, t);
        float bc = Mathf.Lerp(b, c, t);
        float cd = Mathf.Lerp(c, d, t);

        float abbc = Mathf.Lerp(ab, bc, t);
        float bccd = Mathf.Lerp(bc, cd, t);

        return Mathf.Lerp(abbc, bccd, t);
    }


    public override void Process()
    {
       var target = Utils.LookTaget(transform.position, m_target.transform.position);
         
       
    }
}

