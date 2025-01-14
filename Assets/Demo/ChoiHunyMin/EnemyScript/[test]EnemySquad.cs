/*
 * 작성자: 최현민
 * 수정 날짜: 25/01/14
 * 수정 및 추가 내용: 현재상황 군집형 만들예정임
 * 빈오브젝트 만들어서 자식으로 적군 프리팹 5개 오와열을 맞춰서 분대를 만듬
 * 문제점 : prefab1의 0번쨰 프리팹이 사라지면 다같이 사라지게 됨
 * 피드백 : 프리팹은 한개만 쓰고 좌표값을 조정해서 분대형식으로 생기게 하는 게 좋을듯함
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySquad : MonoBehaviour
{    
    [SerializeField]
    private GameObject[] prefab1;
    

    void Update()
    {
        //문제점 : prefab1의 0번쨰 프리팹이 사라지면 다같이 사라지게 됨
        //for (int i = 0; i < prefab1.Length; i++)
        //{
        //    if (prefab1[i] != null) 
        //        {
        //        return;
        //        }
        //
        //    if (prefab1[i] == null)
        //    {
        //        Destroy(gameObject);
        //    }
        //}
    }
}
