using CHM;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

namespace CHM
{
    public class RandomSpawner : MonoBehaviour
    {
        [SerializeField] GameObject enemyPrefep;
        [SerializeField] float circleR;//반지름 값
        [SerializeField] float coolTime;//쿨타임
        float coolTimeup;//증감식
        int circleRandom;
        float speed;
        Vector3 targetPos = new Vector3(0, 0, 0);//기준
        void Update()
        {
            coolTime += Time.deltaTime;

            var angle = GetAngle(transform.position, targetPos);
            transform.rotation = Quaternion.Euler(0, 0, angle);
            Circle();

            if (coolTimeup > coolTime)
            {

                circleRandom = Random.Range(0, 360);
                squadEnemy();


                //Vector3 pos = Random.insideUnitSphere * circleR;
                //Vector2 pos = Random.insideUnitCircle * 10;
                //GetComponent<Rigidbody2D>().velocity = Random.onUnitSphere * 10;
                //transform.position = pos;
                //Normalize();
                coolTime = 0;
            }
        }
        float GetAngle(Vector2 start, Vector2 end)
        {
            Vector2 ver2 = end - start;
            return Mathf.Atan2(ver2.y, ver2.x) * Mathf.Rad2Deg - 90;

        }
        void Circle()
        {
            float x = circleR * Mathf.Cos(circleRandom);//반지름 값
            float y = circleR * Mathf.Sin(circleRandom);
            transform.position = new Vector3(x, y);
        }
        void squadEnemy()
        {
            Instantiate(enemyPrefep, transform.position, transform.rotation);
        }
    }
}