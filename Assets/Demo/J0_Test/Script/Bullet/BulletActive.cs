using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletActive : Bullet
{
    protected override void BulletMovement()
    {
        bulletRigid.AddForce(transform.up.normalized * speed * Time.timeScale, ForceMode2D.Force);
    }
}
