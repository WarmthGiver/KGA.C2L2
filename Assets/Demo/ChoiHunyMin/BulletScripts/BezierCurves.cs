using CHM;
using KGA;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurvesShot : MonoBehaviour
{

    public GameObject bullet; // 미사일 프리팹.
    public GameObject target; // 도착 지점.

    [Header("미사일 조절")]
    public float bulletspeed; // 미사일 속도.
    
    public float distanceFromStart; // 시작 지점을 기준으로 얼마나 꺾일지.
    public float distanceFromEnd; // 도착 지점을 기준으로 얼마나 꺾일지.
    
    public int shotCount; // 총 몇 개 발사할건지.
    [Range(0, 1)] public float interval;
    public int shotCountEveryInterval; // 한번에 몇 개씩 발사할건지.

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
