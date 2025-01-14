using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{// 기능: 플레이어 체력관리, 사망여부

    private int _healthPoint;

    public int HealthPoint
    {
        get { return _healthPoint; }
        set { _healthPoint = value; }
    }


    void Start()
    {
        // 초기 체력 설정
        HealthPoint = 40;
    }

    void Update()
    {
        
    }

    // 체력 차감
    public void DecreaseHealth(int damage)
    {
        HealthPoint -= damage;

        // 플레이어 체력이 0 또는 음수가 되면 사망
        if(HealthPoint <= 0)
        {
            PlayerDie();
        }
    }

    void PlayerDie()
    {
        // GameManager.인스턴스의.사망여부(true)
        // 폭발 이펙트
        Destroy(gameObject);
    }
}
