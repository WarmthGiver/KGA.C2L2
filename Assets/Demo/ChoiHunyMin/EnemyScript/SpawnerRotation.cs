using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRotation : MonoBehaviour
{
    [SerializeField]
    private float spawnerspeed;//빙글빙글 도는 속도
    Vector3 spawnerPos;
    Vector3 targetPos;
    float speed = 0;

    void Update()
    {
        targetPos = new Vector3(0, 0, 0);//목표
        spawnerPos = transform.position;
        speed += Time.deltaTime * spawnerspeed;

        Vector3 angle = spawnerPos - targetPos;//시작점 - 목표 = 거리 = 반지름
        //float rX = angle.x;
        //float rY = angle.y;
        var angle2 = GetAngle(spawnerPos, targetPos);//시작점에서 목표의 각도
                                                     //Vector3 dir = new Vector3(Mathf.Cos(angle2), Mathf.Sin(angle2));   
        float x = 8f * Mathf.Cos(speed);//반지름 값 * 움직일 속도
        float y = 8f * Mathf.Sin(speed);
        Vector3 newPos = new Vector3(x, y);
        transform.position = newPos;

        transform.rotation = Quaternion.Euler(0, 0, angle2);
    }
    float GetAngle(Vector2 start, Vector2 end)//시작점과 끝점에 각도를 구함
    {
        Vector2 ver2 = end - start;
        return Mathf.Atan2(ver2.y, ver2.x) * Mathf.Rad2Deg - 90;
       
    }
}
