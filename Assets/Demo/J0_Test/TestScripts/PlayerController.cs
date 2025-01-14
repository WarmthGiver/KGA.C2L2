using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{// ���: �÷��̾� ü�°���, �������

    private int _healthPoint;

    public int HealthPoint
    {
        get { return _healthPoint; }
        set { _healthPoint = value; }
    }


    void Start()
    {
        // �ʱ� ü�� ����
        HealthPoint = 40;
    }

    void Update()
    {
        
    }

    // ü�� ����
    public void DecreaseHealth(int damage)
    {
        HealthPoint -= damage;

        // �÷��̾� ü���� 0 �Ǵ� ������ �Ǹ� ���
        if(HealthPoint <= 0)
        {
            PlayerDie();
        }
    }

    void PlayerDie()
    {
        // GameManager.�ν��Ͻ���.�������(true)
        // ���� ����Ʈ
        Destroy(gameObject);
    }
}
