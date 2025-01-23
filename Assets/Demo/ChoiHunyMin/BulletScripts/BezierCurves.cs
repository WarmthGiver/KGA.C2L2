using CHM;
using KGA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurvesShot : MonoBehaviour
{

    public GameObject bullet; // �̻��� ������.
    public GameObject target; // ���� ����.

    [Header("�̻��� ����")]
    public float bulletspeed; // �̻��� �ӵ�.
    
    public float distanceFromStart; // ���� ������ �������� �󸶳� ������.
    public float distanceFromEnd; // ���� ������ �������� �󸶳� ������.
    
    public int shotCount; // �� �� �� �߻��Ұ���.
    [Range(0, 1)] public float interval;
    public int shotCountEveryInterval; // �ѹ��� �� ���� �߻��Ұ���.

    private void Update()
    {
           
        if (Input.GetKeyDown(KeyCode.A))
        {
            // Shot.
            StartCoroutine(CreateMissile());
        }
    }

    IEnumerator CreateMissile()
    {
        int shotCount = this.shotCount;
        while (shotCount > 0)                    
        {
            for (int i = 0; i < shotCountEveryInterval; i++)
            {
                if (shotCount > 0)
                {
                    GameObject bullet = Instantiate(this.bullet);
                    bullet.GetComponent<BezierCurvesBullet>().Init
                    (this.gameObject.transform, target.transform, bulletspeed, distanceFromStart, distanceFromEnd);
                    shotCount--;
                }
            }
            yield return new WaitForSeconds(interval);
        }
        yield return null;
    }
}
