using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BulletControl : MonoBehaviour
{
    //테스트용
    [SerializeField] float speed;    
    Vector3 start;
    Vector3 end;

    private void Start()
    {

    }
    void Update()
    {
        end = new Vector3(0,0,0);//일단 플레이어 좌표가 목표 어차피 0,0,0 이라 안꼬이게 함
        start = transform.position;//시작점 여기선 보스가 총알 나가야되서 보스가 시작점
        Vector3 newPos = start - end;//시작점과 끝점의 거리 빗변이라 해야하나       
        var rotZ = GetAngle(start, end);//시작 끝 각도 구하는 메서드 

        Vector3 vec = new Vector3(Mathf.Cos(rotZ), Mathf.Sin(rotZ));
        //보스가 계속 도니까 매 업데이트마다 각도 새로 할당
        //Mathf.Cos(각도)= x  ,  Mathf.Sin(각도) = y
        transform.Translate(vec * speed * Time.deltaTime);
        //총알 속도       
        transform.rotation = Quaternion.Euler(0, 0, rotZ-180);
        //z값 조정 이쁘게 나가게 로테이션을 잘 돌려야 총알 멋진거 구현가능함


        //transform.position += newPos *speed * Time.deltaTime;
       //Quaternion angleAxis = Quaternion.AngleAxis(rotZ + 90f , Vector3.forward);//AngleAxis= 각도 기준으로 각도를 회전
       //Quaternion rotation = Quaternion.Slerp(transform.rotation, angleAxis, speed*Time.deltaTime);
        //transform.rotation = rotation;
    }

    float GetAngle(Vector2 start, Vector2 end)//시작점과 끝점에 각도를 구함
    {
        Vector2 ver2 = end - start;
        return Mathf.Atan2(ver2.y, ver2.x) * Mathf.Rad2Deg +90;
        //라디안 각도를 디그리 각도로 바꿈 +90해야 목표에 도착함
        //높이와 밑변값을 넣어서 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
