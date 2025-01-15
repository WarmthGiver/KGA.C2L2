using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public GameObject bossBullet;
    [SerializeField]
    private float prefabSpeed;//橇府普 积己 加档
    [SerializeField]
    private float coolTime;//酿鸥烙
   
    void Update()
    {
        coolTime += Time.deltaTime;

        if (coolTime > prefabSpeed)
        {

            //Instantiate(enemyPrefab, transform.position, transform.rotation);
            //积己等 局尔 积己窍绰 局尔 度鞍篮 困摹肺 积己

            Instantiate(bossBullet, transform.position, transform.rotation);

            coolTime = 0;
        }
    }
}
