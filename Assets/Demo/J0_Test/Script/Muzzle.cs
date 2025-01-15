using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muzzle : MonoBehaviour
{
    public GameObject bullet;

    private float tempCoolTime;
    private float tempElapsedTime;

    Vector3 bulletPos;
    Quaternion bulletRot;

    void Start()
    {
        tempCoolTime = 0.4f;
    }

    void Update()
    {
        tempElapsedTime += Time.deltaTime;

        if (tempElapsedTime > tempCoolTime)
        {
            FireBullet();

            tempElapsedTime = 0;
        }
    }

    void FireBullet()
    {
        // Bullet »ý¼º
        bulletPos = this.transform.position;
        bulletRot = this.transform.rotation;
        Instantiate(bullet, bulletPos, bulletRot);
        bullet.SetActive(true);
    }
}
